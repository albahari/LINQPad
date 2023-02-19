// LINQPad Statements

// In the default rich-text mode, results are rendered as HTML. With Util.RawHtml, you can emit your own:

Util.RawHtml ("<h1>This is big text</h1>").Dump ("Raw HTML");

// You can also tell LINQPad to add CSS style an existing object before dumping, with the Util.WithStyle
// method that we demonstrated previously:

string[] words = "the quick brown fox".Split();
Util.WithStyle (words, "color:red").Dump ("with style!");