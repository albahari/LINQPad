<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// LINQPad includes HTML controls that you can dump to create interactive queries as an alternative to
// dumping WPF or Windows Forms controls.
//
// Unlike WPF and Windows Forms controls, LINQPad's HTML controls appear alongside results in the main output
// window, and they can respond to events while the query is still running (if you set IsMultithreaded to true).

"LINQPad's controls live in the LINQPad.Controls namespace.".Dump();

var textBox = new TextBox();
textBox.TextInput += (sender, args) => textBox.Text.Dump();
textBox.Dump();

textBox.Focus();