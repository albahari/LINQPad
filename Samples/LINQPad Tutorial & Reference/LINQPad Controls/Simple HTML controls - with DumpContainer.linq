<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// As you type a URI into the textbox below, it automatically creates and dumps a Uri object.
// We use a DumpContainer to update the Uri in place (rather than calling Dump which *appends* to the output window).

var textBox = new TextBox ("http://www.linqpad.net").Dump();

var dc = new DumpContainer (new Uri (textBox.Text)).Dump();

textBox.TextInput += (sender, args) => dc.Content = new Uri (textBox.Text);

textBox.Focus();

// What if you type in a bad URI? You can avoid the error with LINQPad.Util's fluent exception-handling method.
// Replace the last line with the following:
//
// textBox.TextInput += (sender, args) => dc.Content = Util.Try<object> (() => new Uri (textBox.Text), ex => ex);