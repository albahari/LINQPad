// LINQPad Program

#r: "nuget: Avalonia.Desktop"
#r: "nuget: Avalonia.Themes.Fluent"
#r: "nuget: Avalonia.Win32.Interoperability"

using Avalonia
using Avalonia.Controls
using Avalonia.Controls.ApplicationLifetimes
using Avalonia.Data
using Avalonia.Input
using Avalonia.Interactivity
using Avalonia.Layout
using Avalonia.Markup.Xaml
using Avalonia.Media
using Avalonia.Styling
using Avalonia.Themes.Fluent
using Avalonia.Win32.Interoperability
using System.ComponentModel
using System.Threading.Tasks

// Here's the same example implemented with data binding, using Avalonia's special binding syntax.
// (In WPF, you can achieve a similar result by writing a fluent SetBinding extension method.)

// This is the property we're binding to. We could define it in a separate ViewModel class if desired.

bool IsDark     // Using "rename symbol" refactoring won't break anything - because there's no XAML.
{
	get => Application.Current.RequestedThemeVariant == ThemeVariant.Dark;
	set => Application.Current.RequestedThemeVariant = value ? ThemeVariant.Dark : ThemeVariant.Light;
}

CheckBox chkDark;

void Main()
{
	int verticalSpacing = 5;
	Thickness defaultSpacing = new (0, verticalSpacing, 0, verticalSpacing);
	
	var tabControl = new TabControl { DataContext = this, Margin = new Thickness (5) }.AddItems
	(
		new TabItem
		{
			Header = "Options",
			Content = new StackPanel { Margin = defaultSpacing }.AddChildren
			(
				chkDark = new CheckBox
				{
					Content = "Dark",
					// Note Avalonia's cool syntax for data binding (not a typo!):
					[!CheckBox.IsCheckedProperty] = new Binding (nameof (IsDark))
				},
				new TextBox { Margin = defaultSpacing * 2 },
				new ComboBox 
				{
					ItemsSource = Enumerable.Range (0, 20).Select (i => $"Option {i}"),
					SelectedIndex = 0,
					Margin = defaultSpacing
				},
				new RadioButton { Content = "Option 1", Margin = defaultSpacing },
				new RadioButton { Content = "Option 2", Margin = defaultSpacing }
			)
		},
		new TabItem
		{
			Header = "More Options"
		}
	);

	tabControl.Dump();
}

void OnInit()    // Initialize Avalonia subsystem
{
	AppBuilder
		.Configure<Application>()
		.UsePlatformDetect()
		.SetupWithoutStarting();

	// Edit the following line to change the theme. After editing, press Shift+F5 to kill the cached process.
	Application.Current.Styles.Add (new FluentTheme());
	
	if (Util.IsDarkThemeEnabled) 
		Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
}

// With these extension methods, you write a UI fluently in C#.
public static class AvaloniaExtensions
{
	public static T AddChildren<T> (this T uiElement, params Control[] children) where T : Panel
	{
		foreach (var child in children)
			uiElement.Children.Add (child);

		return uiElement;
	}

	public static T AddItems<T> (this T uiElement, params Control[] items) where T : ItemsControl
	{
		foreach (var child in items)
			uiElement.Items.Add (child);

		return uiElement;
	}

	public static T AddClasses<T> (this T c, params string[] classes) where T : Control
	{
		c.Classes.AddRange (classes);
		return c;
	}

	public static T SetDock<T> (this T element, Dock dock) where T : Visual
	{
		if (element == null) throw new ArgumentNullException ("element");
		element.SetValue (DockPanel.DockProperty, dock);
		return element;
	}
}
