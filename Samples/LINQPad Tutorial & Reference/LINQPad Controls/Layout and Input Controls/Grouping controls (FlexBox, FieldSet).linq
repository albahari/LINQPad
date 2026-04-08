<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// You can use an HTML div to group controls horizontally:
new Div (CreateRadioButtons ("Group1")).Dump ("div");

// A more flexible option is to use a (css) FlexBox:
new FlexBox (CreateRadioButtons ("Group2")).Dump ("FlexBox (default properties)");

// With a FlexBox, you can optionally specify:
//  - direction ('row' for the default horizontal stacking of controls, or 'column' for a vertical stacking)
//  - gap between items (in CSS units)
//  - wrap mode ('nowrap', 'wrap', 'wrap-reverse'):
new FlexBox ("row", "1em", "wrap", CreateRadioButtons ("Group3")).Dump ("FlexBox with 1em gap and wrapping");

// You can set Align, AlignContent, Justify, RowGap and ColumnGap via properties.
// Here we set Align to vertically center the label alongside the TextBox:
new FlexBox ("row", "8px", new Label ("Name:"), new TextBox()) { Align = "center" }.Dump ("align:center");

// To set flex properties on child controls, use the fluent AddStyle method.
// Here we create two buttons, one twice as wide as the other:
new FlexBox (
	new Button ("Short").AddStyle ("flex", "1"),
	new Button ("Wide").AddStyle ("flex", "2")
).Dump ("FlexBox with uneven width buttons");

// With the direction set to column, we get a vertical stack of controls:
new FlexBox ("column",
	new Label ("Name:"),
	new TextBox())
.Dump ("FlexBox with Vertical Stack");

// Another vertical stack, this time wrapped in a FieldSet (like a GroupBox):
new FieldSet ("Customer",
	new FlexBox ("column",
		new Label ("First Name"),
		new TextBox(),
		new Label ("Last Name").AddStyle ("margin-top", "5px"),
		new TextBox()
	)
).Dump();

// As with all other controls, you cannot add/remove children after a FlexBox is dumped.
// If you need to do this, use a DumpContainer to swap out the whole FlexBox.

// ADVANCED USE

// All LINQPad controls have a CssChildRules property, which uses a css selector to style multiple children.
// To demo, let's create 3 buttons in a row:
var toolbar = new FlexBox ("row", ".5em", new Button("Save"), new Button("Delete"), new Button("Cancel"));

// Style all buttons with padding and rounded corners:
toolbar.CssChildRules ["> button", "padding"] = "4px 12px";
toolbar.CssChildRules ["> button", "border-radius"] = "6px";
toolbar.CssChildRules ["> button:last-child", "margin-left"] = "auto";      // Push last button to right

toolbar.Dump ("Toolbar with CssChildRules");

// Underneath, FlexBox is very simple: just a subclassed Div with additional styling properties.
// To look inside, uncomment the following line:
// Util.OpenILSpy (typeof (FlexBox));

RadioButton[] CreateRadioButtons (string groupName) => Enumerable.Range (1, 5)
	.Select (i => new RadioButton (groupName, $"Option Number {i}"))
	.ToArray();