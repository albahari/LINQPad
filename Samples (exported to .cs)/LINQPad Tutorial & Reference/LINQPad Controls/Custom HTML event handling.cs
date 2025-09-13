// LINQPad Statements

using LINQPad.Controls;
using System.Globalization;

// You can also respond to JavaScript events that are not exposed in the control.

var div = new Div (new Label ("click me"));
div.Styles ["height"] = "10em";
div.Styles ["width"] = "10em";
div.Styles ["border"] = "1px black solid";

// Just call AddEventListener on the HtmlElement:

div.HtmlElement.AddEventListener ("mousedown", (sender, args) => "mousedown".Dump());

div.Dump();