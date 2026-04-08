// LINQPad Statements

using LINQPad.Controls;

// The TextBox control emits a standard <input type="text">
var textBox = new TextBox().Dump ("Here's a simple textbox");

var button = new Button ("Click me").Dump ("Here's a simple button");

// Responding to button's click event:
button.Click += (sender, args) =>
	textBox.Text = "Updated text";

// TIP: to set a breakpoint in an event handler, uncomment the following line of code:
// Util.KeepRunning();

// Responding to textBox's TextInput event:
textBox.TextInput += (sender, args) =>
	$"You typed: {textBox.Text}".Dump();

textBox.Focus();

// For a multi-line textbox, use the TextArea control instead:
new TextArea().Dump ("TextArea");

