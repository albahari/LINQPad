// LINQPad Statements

using LINQPad.Controls

// You can dump any other HTML element as follows:
var h1 = new Control ("h1", "This is a heading").Dump();

// To apply styles:
h1.Styles ["color"] = "red";

// To set custom attributes:
h1.HtmlElement ["title"] = "My heading";

// You can also attach custom event handlers with HtmlElement.AddEventListener and invoke
// any JavaScript method with HtmlElement.InvokeMethod.

// Instead of specifying content as a string, you can feed in child controls:
var h2 = new Control ("h2", new Span ("This is "), new Control ("u", "flexible")).Dump();

// If you're curious to see the underlying HTML, you can get at it as follows:
var hyperlink = new Hyperlink ("Show me the HTML", h => h2.HtmlElement.ToString (true).Dump("HTML")).Dump();

// To emit raw HTML (without a parent element), use the Literal control, and call DumpInline():
new Literal ("<p>This is part of the ").DumpInline();
new Literal ("same sentence.</p>").DumpInline();

// (If you call Dump instead of DumpInline, the content will be wrapped in a <div>.)
// DumpInline is also useful when dumping non-block elements such as spans.
new Span ("one ").DumpInline();
new Span ("two ").DumpInline();
new Span ("three ").DumpInline();

// You cannot change the content of a literal after it's been dumped (because it has no ID).
// If you need that ability, use a control such as a span or div:
var span = new Span().Dump();
span.HtmlElement.InnerHtml = "<b>This is bold</b>";