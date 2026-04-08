// LINQPad Statements

using LINQPad.Controls;

// The Util.HtmlHead.AddScript method is a shortcut for doing this:

new LINQPad.Controls.Literal ("script", "function foo(x) { external.log(x) }").DumpToHtmlHead();

// You can use the same technique to inject additional elements into the result browser's HTML <head> section.