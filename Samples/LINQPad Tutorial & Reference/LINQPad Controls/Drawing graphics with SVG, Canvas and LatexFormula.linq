<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// With the Sgv control, you can draw complex inline graphics in a single operation:
new Svg ("""
	<rect x='0' y='0' width='200' height='200' fill='tan' />
	<circle cx='100' cy='100' r='75' fill='green' />
	""", 200, 200).Dump("svg");

// You can also use the HTML canvas control for graphics, and draw by executing JavaScript.
// The 'targetElement' variable in JavaScript corresponds to the canvas.
var canvas = new Canvas (200, 120).Dump ("Canvas");
canvas.HtmlElement.Run ("""
	var context = targetElement.getContext('2d');
	context.beginPath();
	context.arc (100, 20, 80, 0, Math.PI);
	context.fillStyle = 'red';
	context.fill();
	""");
// See script://Adding_JavaScript_-_advanced_features for more info on InvokeScript.

// The MarkdownViewer control displays markdown. (This is the same as calling Util.Markdown().)
new MarkdownViewer ("**bold** and *italic*").Dump();

// LINQPad also provides a LatexViewer control, which uses the Katex.js library to display Latex:
string latex = @"\int_0^\infty e^{-x^2} dx";
new LatexViewer (latex, fontSize: "130%").Dump ("Integral");

// See script://Writing_custom_HTML_controls_-_wrapping_a_JavaScript_library 
// for info on how to wrap JavaScript libraries yourself.