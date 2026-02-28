// LINQPad Program

#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Fluent"
#r "nuget: Avalonia.Win32.Interoperability"

// This uses LINQPad's runtime AI integration to implement a Chatbot, using Avalonia for the UI.
// (This was largely written with LINQPad's AI coding agent).

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using LINQPad.ObjectModel.AI;
using System.Threading.Tasks;

const string SystemPrompt = "You are a helpful, friendly AI assistant. Be concise but thorough.";

TextBox inputBox;
StackPanel chatPanel;
ScrollViewer scrollViewer;
Button sendButton;
ComboBox modelSelector;
List<AIMessage> chatHistory = new();

async Task Main()
{	
	var mainPanel = new DockPanel { Margin = new Thickness (10) }.AddChildren
	(
		new DockPanel().SetDock (Dock.Bottom).AddChildren
		(
			sendButton = new Button
			{
				Content = "Send",
				Margin = new Thickness (8, 0, 0, 0),
				VerticalAlignment = VerticalAlignment.Stretch,
				Padding = new Thickness (15, 5),
			}
			.SetDock (Dock.Right),

			modelSelector = new ComboBox
			{
				ItemsSource = AIModel.All.Where (m => !m.IsHidden).ToList(),
				SelectedItem = AIModel.DefaultChatModel,
				Margin = new Thickness (8, 0, 0, 0),
				VerticalAlignment = VerticalAlignment.Stretch,
				MinWidth = 150
			}
			.SetDock (Dock.Right),

			inputBox = new TextBox
			{
				Watermark = "Type your message...",
				AcceptsReturn = false,
				TextWrapping = TextWrapping.Wrap,
				MinHeight = 35
			}
		),
		new Border
		{
			BorderBrush = Brushes.Gray,
			BorderThickness = new Thickness (1),
			CornerRadius = new CornerRadius (5),
			Margin = new Thickness (0, 0, 0, 10),
			Child = scrollViewer = new ScrollViewer
			{
				Content = chatPanel = new StackPanel { Spacing = 8 },
				VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
				Padding = new Thickness (5)
			}
		}
	);

	inputBox.KeyDown += (s, e) =>
	{
		if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace (inputBox.Text))
			SendMessage();
	};
	
	sendButton.Click += (s, e) => SendMessage();

#if MACOS
	Application.Current.Run (new Window { Content = mainPanel, Topmost = true });
	Environment.Exit (0);
#else
	mainPanel.Dump ("Avalonia Chatbot");
#endif
}

async void SendMessage()
{
	var userMessage = inputBox.Text?.Trim();
	if (string.IsNullOrEmpty (userMessage)) return;

	inputBox.Text = "";
	inputBox.IsEnabled = false;
	sendButton.IsEnabled = false;

	AddMessage (userMessage, isUser: true);
	chatHistory.Add (new AIMessage (AIRole.User, userMessage));

	var responseBlock = AddMessage ("Thinking...", isUser: false);

	try
	{
		var options = new AIRequestOptions 
		{
			ChatHistory = chatHistory.ToList(),
			SystemPrompt = SystemPrompt,
			Model = modelSelector.SelectedItem as AIModel
		};
		var response = await Util.AI.Ask (userMessage, options).GetResponseAsync();
		responseBlock.Text = response.Text;
		chatHistory.Add (new AIMessage (AIRole.Assistant, response.Text));
	}
	catch (Exception ex)
	{
		responseBlock.Text = $"Error: {ex.Message}";
	}
	finally
	{
		inputBox.IsEnabled = true;
		sendButton.IsEnabled = true;
		inputBox.Focus();
		scrollViewer.ScrollToEnd();
	}
}

TextBlock AddMessage (string text, bool isUser)
{
	TextBlock textBlock;
	
	chatPanel.Children.Add (new Border
	{
		Background = isUser
			? new SolidColorBrush (Color.Parse ("#0078D4"))
			: new SolidColorBrush (Color.Parse (Util.IsDarkThemeEnabled ? "#3A3A3A" : "#E5E5E5")),
		CornerRadius = new CornerRadius (12),
		Padding = new Thickness (12, 8),
		MaxWidth = 500,
		HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left,
		Child = textBlock = new TextBlock
		{
			Text = text,
			TextWrapping = TextWrapping.Wrap,
			Foreground = isUser
				? Brushes.White
				: new SolidColorBrush (Color.Parse (Util.IsDarkThemeEnabled ? "#FFFFFF" : "#000000"))
		}
	});
	scrollViewer.ScrollToEnd();

	return textBlock;
}

void OnInit()
{
	AppBuilder
		.Configure<Application>()
		.UsePlatformDetect()
		.SetupWithoutStarting();

	Application.Current.Styles.Add (new FluentTheme());

	if (Util.IsDarkThemeEnabled)
		Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
}

public static class FluentExtensions
{
	public static T AddChildren<T> (this T panel, params Control[] children) where T : Panel
	{
		foreach (var child in children)
			panel.Children.Add (child);
		return panel;
	}

	public static T SetDock<T> (this T control, Dock dock) where T : Control
	{
		DockPanel.SetDock (control, dock);
		return control;
	}
}

