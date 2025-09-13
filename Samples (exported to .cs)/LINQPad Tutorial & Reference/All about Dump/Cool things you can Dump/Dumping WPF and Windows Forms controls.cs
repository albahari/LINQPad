// LINQPad Expression

using System.Windows.Controls;
using System.Windows;

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