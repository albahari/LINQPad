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

void Main()
{
	// You can use Avalonia in LINQPad.
	// Under Windows, you can Dump Avalonia controls and LINQPad will render them in the output panel (just like with WPF and WinForms controls).
	// Under macOS, call Application.Current.Run with a new Window.

	var btn = new Button { Content = "Avalonia rocks!", HorizontalAlignment = HorizontalAlignment.Center };
	btn.Click += (sender, args) => btn.Content = "Clicked";
	
#if MACOS
	Application.Current.Run (new Window { Content = btn, Topmost = true });
	Environment.Exit (0);
#else
	btn.Dump ("Avalonia");
#endif
}

// The OnInit() hook method in LINQPad executes once when your process starts.
// This is where we need to initialize the Avalonia subsystem.

void OnInit()
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
