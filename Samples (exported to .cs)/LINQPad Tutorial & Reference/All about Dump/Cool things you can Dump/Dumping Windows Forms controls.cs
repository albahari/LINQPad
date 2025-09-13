// LINQPad Statements

using System.Windows.Forms;

// NB: Windows Forms is not supported on macOS.

// You can also dump Windows Forms controls:
new TextBox { Multiline = true, Text = "Hello" }.Dump ("TextBox 1");

// Each time you dump a WinForms control, it always renders in its own panel, filling the whole panel:
new TextBox { Multiline = true, Text = "World" }.Dump ("TextBox 2");  // Renders another panel

// LINQPad also provides HTML controls that you can dump inline.
// See script://../../LINQPad_Controls