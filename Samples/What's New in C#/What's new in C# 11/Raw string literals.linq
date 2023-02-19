<Query Kind="Statements" />

// C# 11 supports raw string literals, denoted by triple quotes (""").
// Raw string literals can include quotes and backslahes and are great
// for JSON strings, source code and RegEx expressions.
//
// Raw string literals can be single-line or multi-line.
// With single-line syntax, everything is on one line:

string raw1 = """{ "Name" : "file.txt", "Directory" : "c:\temp" }""";

// With multi-line syntax:
//    - a newline follows the opening """
//    - a newline precedes the closing """
// (those newlines do not form part of the string)

string raw2 = """
	{
		"Name" : "file.txt",
		"Directory" : "c:\temp"
	}
	""";
	
Util.SyntaxColorText (raw1, SyntaxLanguageStyle.Json).Dump ("Single-line raw string literal");
Util.SyntaxColorText (raw2, SyntaxLanguageStyle.Json).Dump ("Multi-line raw string literal");

(raw2 == raw2.Trim()).Dump ("Our multi-line literal does not have leading/trailing newlines");

// The compiler removes common indentation. Specifically, if all lines start with at
// least x characters of whitespace, those x characters will be removed from each line.
// A nice touch is that the compiler checks your use of tabs vs spaces in the common
// whitespace. If it detects inconsistencies, it emits a helpful error (rather than
// leaving you wondering why it failed to remove the common indentation).

// With multi-line raw string literals, a newline must immediately follow the opening """
// and immediately precede the closing """ (except for whitespace, which is ignored).
// So, the following is illegal:
//
// string illegal =
//    """Test
//    string""";     // Will not compile! (we broke both of those rules)

// If you need to represent three consecutive quotes in a raw string literal, use four
// quotes instead as a delimiter. You can use as many quotes as you like:

""""This includes """ three quotes"""".Dump();

// This feature liberates raw string literals from needing to support escape sequences.

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/raw-string-literal.md