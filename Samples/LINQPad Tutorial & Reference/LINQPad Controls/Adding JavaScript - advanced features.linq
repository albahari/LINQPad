<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// When you call InvokeScript on a control, you can access the target element
// in JavaScript via the 'targetElement' variable:

var button = new Button ("Test").Dump();
button.HtmlElement.InvokeScript (false, "eval", "targetElement.innerText = 'Something else!'");

// Here's another example:
var canvas = new Canvas (200, 120).Dump ("Canvas");

canvas.HtmlElement.InvokeScript (false, "eval", @$"
var context = targetElement.getContext('2d');
context.beginPath();
context.arc (100, 20, 80, 0, Math.PI);
context.strokeStyle = 'brown';
context.fillStyle = 'red';
context.lineWidth = '5';
context.closePath();
context.fill();
context.stroke();");

// The follow enables JQuery (you would probably do this at the start of the query):
Util.HtmlHead.AddScriptFromUri ("https://code.jquery.com/jquery-3.4.1.min.js");

Util.InvokeScript (false, "eval", $"$( 'button' ).html( 'Set via JQuery...' )");

// For more advanced JavaScript scenarios, see query://Demo_-_Bing_Maps