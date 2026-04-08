// LINQPad Statements

using LINQPad.Controls;
using System.Threading.Tasks;

// To emit raw static HTML, use the Literal control:
new Literal ("<ul><li>List item</li></ul>").Dump();

// Note that you cannot update a literal after it's been dumped (because it has no ID).
// If you need that ability, use a wrapper control such as a span or div:
var span = new Div().Dump();
span.HtmlElement.InnerHtml = "<ul><li>List item</li></ul>";

// You can also do this:
var ul = new Control ("ul").Dump();
ul.HtmlElement.InnerHtml = "<li>List item</li>";

// You can put a literal inside other 
new Div (new Span ("span"), new Literal ("<b>bold</b>")).Dump();

// Do not use Util.RawHtml for this - it's won't go inside controls
// WRONG: new Div (Util.RawHtml ("<b>bold</b>")).Dump();  // Illegal