// LINQPad Statements

using LINQPad.Controls

// Most of the controls have constructors which let you attach commonly-used event handlers in one easy step.
// We can simplify the preceding example as follows:

var textBox = new TextBox (onTextInput: txt => $"You typed: {txt.Text}".Dump()).Dump();

var button = new Button ("Click me", onClick: btn => textBox.Text = "Updated text").Dump();

textBox.Focus();