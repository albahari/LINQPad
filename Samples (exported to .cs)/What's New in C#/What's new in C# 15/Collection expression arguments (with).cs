// LINQPad Statements

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// In C# 15, collection expressions support a new `with(...)` element that forwards
// constructor arguments to the target collection type.

HashSet<string> languages =
[
	with (StringComparer.OrdinalIgnoreCase),  // This gets passed to the constructor.
	"C#",
	"F#",
	"TypeScript",
	"Python"
];

languages.Dump();

languages.Add ("c#");
languages.Dump();