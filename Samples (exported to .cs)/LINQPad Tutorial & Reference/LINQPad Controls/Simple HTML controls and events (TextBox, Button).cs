// LINQPad Statements

using LINQPad.Controls;

var textBox = new TextBox().Dump ("Here's a simple textbox");

var button = new Button ("Click me").Dump ("Here's a simple button");

// Responding to button's click event:
button.Click += (sender, args) => textBox.Text = "Updated text";

// Responding to textBox's TextInput event:
textBox.TextInput += (sender, args) => $"You typed: {textBox.Text}".Dump();

textBox.Focus();

// For a multi-line textbox, use the TextArea control instead.