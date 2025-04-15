<Query Kind="Statements" />

// The compiler removes common indentation from multiline raw string literals.
// Specifically, if all lines start with at least x characters of whitespace,
// those x characters will be removed from each line.

string notIndented = """
	Line 1
	Line 2
	""".Dump ("not indented");

// The compiler also looks at the terminating """ token when deciding how much
// indentation to remove. This means that if you need to include common indentation,
// you can do so like this:

string indented = """
	Line 1
	Line 2
""".Dump ("indented by 1 tab");

// or this:

string alsoIndented = """
		Line 1
		Line 2
	""".Dump ("also indented by 1 tab");

// A nice touch is that the compiler checks your use of tabs vs spaces in the common
// whitespace. If it detects inconsistencies, it emits a helpful error (rather than
// leaving you wondering why it failed to remove the common indentation).

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/raw-string-literal.md