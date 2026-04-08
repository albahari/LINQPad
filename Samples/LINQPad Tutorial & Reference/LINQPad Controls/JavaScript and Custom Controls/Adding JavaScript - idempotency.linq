<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// The methods on HtmlHead are idempotent, so you can safely call them again with the same text
// without ending up with multiple entries.

// After running the following, we end up with only one script:

for (int i = 0; i < 100000; i++)
{
	// Subsequent calls are ignored because we already called AddScript with same text:
	Util.HtmlHead.AddScript ("function foo(x) { external.log(x) }");
}

// This feature is handy if you need to emit a script for a custom control: if multiple instances
// of that control are dumped, you only want to the script to appear once.

Util.JS.RunFunction ("foo", "test");   // Just one foo has been defined!