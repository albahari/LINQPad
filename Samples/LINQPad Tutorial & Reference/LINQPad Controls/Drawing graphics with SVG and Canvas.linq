<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// With the Sgv control, you can draw complex inline graphics in a single operation:

var svg = new Svg ("""
	<rect x='0' y='0' width='200' height='200' fill='tan' />
	<circle cx='100' cy='100' r='75' fill='green' />
	""", 200, 200);

svg.Dump ("svg");

// You can also use the HTML canvas control for graphics, and draw by executing JavaScript.

var canvas = new Canvas (200, 120).Dump ("Canvas");

// The 'targetElement' variable in JavaScript corresponds to the canvas.

canvas.HtmlElement.Run ("""
	var context = targetElement.getContext('2d');
	context.beginPath();
	context.arc (100, 20, 80, 0, Math.PI);
	context.fillStyle = 'red';
	context.fill();
	""");

// See script://Adding_JavaScript_-_advanced_features for more info on InvokeScript.