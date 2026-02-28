// LINQPad Statements

using LINQPad.Controls;

var textArea = new TextArea ("Text area").Dump ("A TextArea control.");

// As the controls are implemented as HTML input elements, you can style them with CSS expressions:
textArea.Styles ["font-family"] = "Consolas,Courier New";

// There's also a fluent .AddStyle extension method in the LINQPad.Controls namespace:
new Label ("Test")
	.AddStyle ("padding", "10px")
	.AddStyle ("font-size", "20pt")
	.Dump();

// Note that with controls, we set styles *individually* (unlike with Util.WithStyle and DumpContainer.Style).
// WRONG: new Label ("Test").AddStyle ("padding: 10px; font-size: 20pt").Dump(); // Will not compile!

// The following listbox changes color as you select items:
var listBox = new SelectBox (SelectBoxKind.ListBox,
	new[] { "Red", "Green", "Violet", "Blue", "Orange" },
	onSelectionChanged: lst => lst.Styles ["background"] = lst.SelectedOption.ToString()
).Dump ("Listbox");
	
// To add CSS style declarations at the document level:
Util.HtmlHead.AddStyles ("button { color:orange }");
var btn = new Button ("Orange").Dump();
