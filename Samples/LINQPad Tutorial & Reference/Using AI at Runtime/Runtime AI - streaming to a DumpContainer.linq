<Query Kind="Statements" />

// You can also stream a response to a LINQPad DumpContainer.
// This gives you the following features for free:
//  - streaming
//  - markdown formatting
//  - an inline Cancel button.

var dc = new DumpContainer().Dump ("AI Response");

var response = await Util.AI
	.Ask ("Is gravity considered a fundamental force in physics?")
	.GetResponseAsync (dc, ScriptCancelToken);

// The result is similar to the first example, where we called Util.Ask(...).Dump(),
// except that now we also have programmatic access to the response Text:
response.Text.Length.Dump ("Response length");