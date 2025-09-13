// LINQPad Statements

using LINQPad.Controls;

// Sometimes you need to access a LINQPad control from within JavaScript.
// To do this, LINQPad provides Eval and RUn methods on HtmlElement.
// These set up a variable called 'targetElement' which refers to the control.

var button = new Button ("Test").Dump();
button.HtmlElement.Run ("targetElement.innerText = 'Something else!'");

// Note that LINQPad delays script execution until the element has been dumped and rendered.

// Here's another example:
var canvas = new Canvas (200, 120).Dump ("Canvas");

canvas.HtmlElement.Run ("""
	var context = targetElement.getContext('2d');
	context.beginPath();
	context.arc (100, 20, 80, 0, Math.PI);
	context.strokeStyle = 'brown';
	context.fillStyle = 'red';
	context.lineWidth = '5';
	context.closePath();
	context.fill();
	context.stroke();
	""");