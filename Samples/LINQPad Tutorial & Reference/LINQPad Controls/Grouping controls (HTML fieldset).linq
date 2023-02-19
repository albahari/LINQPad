<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// You can use an HTML div to group controls horizontally:
new Div (
	new RadioButton ("group1", "Option 1"),
	new RadioButton ("group1", "Option 2"),
	new RadioButton ("group1", "Option 3")).Dump();

// The WrapPanel lets you specify a gap between items, and works with both inline and block HTML elements.
// You can also specify a vertical-alignment for children.
new WrapPanel (".5em",
	new RadioButton ("group2", "Option 1"),
	new RadioButton ("group2", "Option 2"),
	new RadioButton ("group2", "Option 3")).Dump();

// A StackPanel lays out controls in a single row or column.
// Here's a StackPanel contained within an HTML FieldSet (GroupBox):
new FieldSet ("Customer",
	new StackPanel (false, ".1em",
		new Span ("First Name"),
		new TextBox(),
		new Span ("Last Name"),
		new TextBox()
	)).Dump();

// There's an implicit conversion from DumpContainer to Control, so you can put DumpContainers *inside* controls:

var dc = new DumpContainer();
var txt = new TextBox (onTextInput: t => dc.Content = t.Text.Split());
new FieldSet ("Let me split words for you", txt, dc).Dump();
