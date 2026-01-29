<Query Kind="Statements" />

// You can also stream a response to a LINQPad DumpContainer.
// This gives you nice markdown formatting and an inline Cancel button for free.

var dc = new DumpContainer().Dump ("AI Response");

var response = await Util.AI
	.Ask ("Is gravity considered a fundamental force in physics?")
	.GetResponseAsync (dc, ScriptCancelToken);

// This is similar to the first example, where we called Util.Ask(...).Dump(), except
// that now we have programmatic access to the response Text.

response.Text.Length.Dump ("Response length");