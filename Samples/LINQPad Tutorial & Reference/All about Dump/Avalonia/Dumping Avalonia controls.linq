<Query Kind="Program">
  <NuGetReference>Avalonia.Desktop</NuGetReference>
  <NuGetReference>Avalonia.Themes.Fluent</NuGetReference>
  <NuGetReference>Avalonia.Win32.Interoperability</NuGetReference>
  <Namespace>Avalonia</Namespace>
  <Namespace>Avalonia.Controls</Namespace>
  <Namespace>Avalonia.Controls.ApplicationLifetimes</Namespace>
  <Namespace>Avalonia.Data</Namespace>
  <Namespace>Avalonia.Input</Namespace>
  <Namespace>Avalonia.Interactivity</Namespace>
  <Namespace>Avalonia.Layout</Namespace>
  <Namespace>Avalonia.Markup.Xaml</Namespace>
  <Namespace>Avalonia.Media</Namespace>
  <Namespace>Avalonia.Styling</Namespace>
  <Namespace>Avalonia.Themes.Fluent</Namespace>
  <Namespace>Avalonia.Win32.Interoperability</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// When you dump Avalonia controls, LINQPad renders them in the output panel (just like with WPF and WinForms controls).

	var btn = new Button { Content = "Avalonia rocks!", HorizontalAlignment = HorizontalAlignment.Center }.Dump ("Avalonia");
	btn.Click += (sender, args) => btn.Content = "Clicked";
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
