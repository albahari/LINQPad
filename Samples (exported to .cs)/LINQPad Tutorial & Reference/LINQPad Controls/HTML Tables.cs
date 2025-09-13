// LINQPad Statements

using LINQPad.Controls;

var table = new Table (noBorders:true, cellVerticalAlign:"middle");

// Specifying cellVerticalAlign in the constructor is a shortcut for doing this:
// table.CellStyles ["vertical-align"] = "middle";

table.Rows.Add (new Label ("First name"), new TextBox());
table.Rows.Add (new Label ("Last name"), new TextBox());
table.Rows.Add (new Label ("City"), new TextBox());
table.Rows.Add (new Label ("Post code"), new TextBox());

table.Dump();     // You must dump the table *after* adding the rows.

new Button (
	"Give me alternating row color!", 
	// You can do some cool things with CssChildRules (hover over the property to see help).
	b => table.CssChildRules ["tr:nth-child(even)", "background"] = "beige"
	).Dump();

new Button (
	"I'm curious... show me the HTML",
	b => table.HtmlElement.ToString(true).Dump()
	).Dump();