// LINQPad Program

#r: "nuget: Avalonia.Desktop"
#r: "nuget: Avalonia.Themes.Fluent"
#r: "nuget: Avalonia.Win32.Interoperability"

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using System.ComponentModel;
using System.Threading.Tasks;

// You can build a user interface with C# as easily as with XAML, with a few extension methods
// such as AddChildren and AddItems, which we have defined below. (The same trick works with WPF.)

CheckBox chkDark;

void Main()
{
	int verticalSpacing = 5;
	Thickness defaultSpacing = new (0, verticalSpacing, 0, verticalSpacing);
	
	var tabControl = new TabControl { Margin = new Thickness (5) }.AddItems
	(
		new TabItem                                    // Our code has the same shape as XAML
		{                                              // but we have all the power of C#.
			Header = MakeHeader ("Options"),
			Content = new StackPanel { Margin = defaultSpacing }.AddChildren
			(
				chkDark = new CheckBox 
				{
					Content = "Dark",
					IsChecked = Application.Current.RequestedThemeVariant == ThemeVariant.Dark
				},
				new TextBox { Margin = defaultSpacing * 2 },     // We can even multiply :)
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
			Header = MakeHeader ("More Options")
		}
	);
	
	object MakeHeader (string text) => text;   // We could easily add code here to include an image or glyph in 
	                                           // the header without creating custom controls or templates

	chkDark.Click += (sender, args) =>
		Application.Current.RequestedThemeVariant = chkDark.IsChecked == true ? ThemeVariant.Dark : ThemeVariant.Light;

#if MACOS
	Application.Current.Run (new Window { Content = tabControl, Topmost = true });
	Environment.Exit (0);
#else
	tabControl.Dump();
#endif

	// This trick of using C# instead of XAML works equally well in Visual Studio, and is how LINQPad's AI user interface
	// was written (using WPF as the backend). C# is much better than XAML at enabling code reuse and avoiding repetition.
	// No more resource dictionaries, markup extensions and their restrictions: just use variables & methods!
	// Dynamic UI becomes easy. C# also lets you fully leverage Visual Studio's refactoring ability.
	// You can still separate your UI from your model and use MVVM - separation doesn't require different languages.
}

// Tip: to avoid defining OnInit and AvaloniaExtensions in every script, save this script to My Queries and then
// use the #load directive to import it into other scripts (e.g.: #load "Avalonia").

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
