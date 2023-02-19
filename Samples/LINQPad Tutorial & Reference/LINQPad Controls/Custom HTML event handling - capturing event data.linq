<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

// You can capture JavaScript event data and return it to the C# event handler.

var div = new Div (new Label ("click me"));
div.Styles ["height"] = "10em";
div.Styles ["width"] = "10em";
div.Styles ["border"] = "1px black solid";

// Specify the event properties that you want to capture using the following overload of AddEventListener:

div.HtmlElement.AddEventListener (
	"mousedown",
	new[] { "offsetX", "offsetY" },
	(sender, args) => args.Properties.Dump ("Simple event properties"));

// (Note that this returns event data only if you're using the Chromium browser engine.)

// The following captures all event properties, and is handy for exploration:
// div.HtmlElement.AddEventListener ("mousedown", new[] { "*" }, (sender, args) => args.Properties.Dump ("All props"));

// AddEventListener also supports a special syntax for returning calculated values:

div.HtmlElement.AddEventListener (
	"mousedown",
	new[]
	{
		"XFraction: args.offsetX / targetElement.clientWidth",
		"YFraction: args.offsetY / targetElement.clientHeight"
	},
	(sender, args) => args.Properties.Dump ("Calculated properties"));

// Note that 'args' denotes the event arguments; 'targetElement' denotes the HtmlElement.
// With this syntax, you can refer to any JavaScript variable in scope, such as 'document' and 'window'.

div.Dump();

// You can also handle custom events that you define in JavaScript.
// For an example, see query://Demo_-_Bing_Maps