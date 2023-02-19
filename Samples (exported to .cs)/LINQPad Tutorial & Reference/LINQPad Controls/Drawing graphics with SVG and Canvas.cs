// LINQPad Statements

using LINQPad.Controls

// With SGV, you can draw complex inline graphics in a single operation:

var svg = new Svg (@"<rect x='0' y='0' width='200' height='200' fill='tan' stroke-width='3' stroke='brown' />
<circle cx='100' cy='100' r='75' fill='green' />
<line x1='20' y1='180' x2='180' y2='20' stroke='white' stroke-width='10' />", 200, 200);

svg.Dump ("svg");

// You can also use the HTML canvas control for graphics, and draw by executing JavaScript.

var canvas = new Canvas (200, 120).Dump ("Canvas");

// The 'targetElement' variable in JavaScript corresponds to the canvas.

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

// See query://Adding_JavaScript_-_advanced_features for more info on InvokeScript.