// LINQPad Statements

using LINQPad.Controls;

// LINQPad includes HTML controls that you can dump to create interactive scripts as an alternative to
// dumping WPF or Windows Forms controls.
//
// Unlike WPF and Windows Forms controls, LINQPad's HTML controls appear alongside results in the main output
// window, and they can respond to events while the script is still running (if you set IsMultithreaded to true).
// They also work on both Windows and macOS.

"LINQPad's controls live in the LINQPad.Controls namespace.".Dump();

var textBox = new TextBox();
textBox.TextInput += (sender, args) => textBox.Text.Dump();
textBox.Dump();

textBox.Focus();

// HTML renders using the Edge Chromium engine under Windows, and the Safari engine under macOS. 

// Tip: LINQPad's AI agent knows all about LINQPad controls. Press Ctrl+I / Command-I and ask it to write something!