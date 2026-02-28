<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// You can use an HTML div to group controls horizontally:
new Div (
	new RadioButton ("group1", "Option 1"),
	new RadioButton ("group1", "Option 2")).Dump();

// The WrapPanel lets you specify a gap between items, and works with both inline and block HTML elements.
// You can also specify a vertical-alignment for children.
new WrapPanel (".5em",
	new RadioButton ("group2", "Option 1"),
	new RadioButton ("group2", "Option 2")).Dump();

// A StackPanel lays out controls vertically or horizontally.
// Here's a vertical StackPanel contained within an HTML FieldSet (GroupBox):
new FieldSet ("Customer",
	new StackPanel (horizontal:false, gap:".1em",
		new Span ("First Name"),
		new TextBox(),
		new Span ("Last Name"),
		new TextBox()
	)).Dump();

// For more elaborate layouts, you can create a flexbox with a Div and CSS flex styles:
var flexContainer = new Div (
	new TextArea ("Left side"),
	new TextArea ("Right side")
);
flexContainer.Styles ["display"] = "flex";
flexContainer.Styles ["gap"] = "1em";
flexContainer.CssChildRules ["> textarea", "flex"] = "1";    // Emits <style type="text/css">#flexContainer > textarea{flex:1}</style>
flexContainer.Dump ("Flexbox with two equal-width children");

