// LINQPad Statements

using LINQPad.Controls

var textArea = new TextArea ("Text area").Dump ("A TextArea control.");

// As the controls are implemented as HTML input elements, you can style them with CSS expressions:
textArea.Styles ["font-family"] = "Consolas,Courier New";

// The following listbox changes color as you select items:
var listBox = new SelectBox (SelectBoxKind.ListBox,
	new[] { "Red", "Green", "Violet", "Blue", "Orange", "Yellow" },
	onSelectionChanged: lst => lst.Styles ["background"] = lst.SelectedOption.ToString()
	).Dump ("Listbox");
	
// To add CSS style declarations at the document level:
Util.HtmlHead.AddStyles ("button { color:blue }");
var btn = new Button ("Blue").Dump();
