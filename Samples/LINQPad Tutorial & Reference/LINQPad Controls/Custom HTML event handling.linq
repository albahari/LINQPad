<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

// You can also respond to JavaScript events that are not exposed in the control.

var div = new Div (new Label ("click me"))
	.WithStyle ("height", "10em")
	.WithStyle ("width", "10em")
	.WithStyle ("border", "1px orange solid");

// Just call AddEventListener on the HtmlElement:

div.HtmlElement.AddEventListener ("mousedown", (sender, args) => "mousedown".Dump());

div.Dump();