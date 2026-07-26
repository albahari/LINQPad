<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// After a control is dumped, you can change its attributes and styles, as we saw previously,
// but you cannot add/remove child controls.

// You can, however, use a DumpContainer to dynamically replace controls.
// A DumpContainer can contain controls, and itself be put *inside* a control.
// (This works because there's an implicit conversion from DumpContainer to Control.)

// Here's a simple todo list that demonstrates this:

var items = new List<string>();
var dc = new DumpContainer();

void Refresh() => dc.Content = items.Count == 0
	? (object)"No items yet."
	: new Div (items.Select ((item, i) => new Div (new Span ($"{i + 1}. {item}"))));

Refresh();

var input = new TextBox();
new Div (
	new Span (input, new Button ("Add", _ => { items.Add (input.Text); input.Text = ""; Refresh(); })),
	dc
).Dump ("Todo List");

