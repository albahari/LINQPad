<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// You can dump any other HTML element as follows:
var h1 = new Control ("h1", "This is a heading").Dump();

// To apply styles:
h1.Styles ["color"] = "red";

// To set custom attributes:
h1.HtmlElement ["title"] = "My heading";

// You can also attach custom event handlers with HtmlElement.AddEventListener and invoke
// any JavaScript method with HtmlElement.RunMethod or HtmlElement.EvalMethod.

// Instead of specifying content as a string, you can feed in child controls:
var h2 = new Control ("h2", new Span ("This is "), new Control ("u", "flexible")).Dump();

// If you're curious to see the underlying HTML, you can get at it as follows:
var hyperlink = new Hyperlink ("Show me the HTML", h => h2.HtmlElement.ToString (true).Dump("HTML")).Dump();