// LINQPad Statements

// The Decompile() extension method also works on individual members (methods, properties,
// fields, events) and collections of members.

// Decompile a single method:

typeof (string).GetMethod ("Contains", new[] { typeof (string) })
	.Decompile().Dump ("string.Contains(string)");

// Decompile all overloads of a method:

typeof (string).GetMethods ().Where (m => m.Name == "Split")
	.Decompile().Dump ("string.Split overloads");

// You can also show signatures only:

typeof (string).GetMethods ().Where (m => m.Name == "Split")
	.Decompile (signaturesOnly: true).Dump ("string.Split signatures");

// Decompile a property:

typeof (string).GetProperty ("Length")
	.Decompile().Dump ("string.Length property");

// You can also use SyntaxColoredText's .Text property to get the plain text.
// This is useful when piping the output to other tools or when scripting:

string text = typeof (Uri).Decompile (signaturesOnly: true).Text;
text.Dump ("Plain text output");
