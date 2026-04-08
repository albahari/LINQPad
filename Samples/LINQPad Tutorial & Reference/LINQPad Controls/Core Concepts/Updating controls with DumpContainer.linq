<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// After a control is dumped, you can change its attributes and styles, as we saw previously,
// but you cannot add/remove child controls.

// You can, however, use a DumpContainer to dynamically replace controls.
// A DumpContainer can contain controls, and itself be put *inside* a control.
// (This works because there's an implicit conversion from DumpContainer to Control.)

// Here's a simple todo list that demonstrates this:

var todos = new List<string>();
var todoList = new DumpContainer();
var input = new TextBox();
var addButton = new Button ("Add", _ =>
{
	todos.Add (input.Text);
	input.Text = "";
	Refresh();
});

new FieldSet ("Todo List",
	new FlexBox ("row", ".5em", input, addButton).AddStyle ("margin-bottom", ".5em"),
	todoList
).Dump();

Refresh();

void Refresh() => todoList.Content =
	new FlexBox ("column", ".5em",
		todos.Select ((todo, i) =>
			new FlexBox ("row", ".5em",
				new Button ("✓", _ => { todos.RemoveAt (i); Refresh(); }),
				new Span (todo))
			{
				Align = "center"
			}
		));
