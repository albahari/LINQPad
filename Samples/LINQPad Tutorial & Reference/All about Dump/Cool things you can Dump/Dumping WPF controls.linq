<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

// NB: WPF is not supported on macOS.

// To dump WPF controls, call the .DumpToWholePanel() extension method.
new TextBox { Text = "Hello, world", FontSize = 20 }.DumpToWholePanel ("Demo TextBox");

new GroupBox 
{
	Header = "You can dump WPF controls",
	Content = new TextBox 
	{
		Text = "and they will render! You can use this to create custom visualizers."
	},
	Padding = new Thickness (5)	
}.DumpToWholePanel ("WPF Demo");

// If you call .Dump() on a WPF control, it will add the control to a StackPanel (in the same panel):
new Label { Content = "Line 1" }.Dump();
new Label { Content = "Line 2" }.Dump();
new Label { Content = "Line 3" }.Dump();

// For controls that don't auto-size, you must assign a height if calling .Dump():
new Border { Background = Brushes.PaleGoldenrod, Height = 20 }.Dump();

// You can also dump Avalonia controls.
// See script://../Avalonia

// LINQPad also provides HTML controls that you can dump inline.
// See script://../../LINQPad_Controls