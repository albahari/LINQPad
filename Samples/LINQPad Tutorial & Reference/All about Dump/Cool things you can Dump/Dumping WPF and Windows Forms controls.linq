<Query Kind="Expression">
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
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows</Namespace>
</Query>

// NB: WPF and Windows Forms is not supported on macOS.

new GroupBox 
{
	Header = "You can dump WPF and Windows Forms controls",
	Content = new TextBox 
	{
		Text = "and they will render! You can use this to create custom visualizers."
	},
	Padding = new Thickness (5)	
}

// You can also dump Avalonia controls.
// See script://../Avalonia

// LINQPad also provides HTML controls that you can dump inline.
// See script://../../LINQPad_Controls