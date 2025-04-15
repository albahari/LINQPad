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

(raw2 == raw2.Trim()).Dump ("Our multi-line literal does not include leading/trailing newlines");

// With multi-line raw string literals, a newline must immediately follow the opening """
// and immediately precede the closing """ (except for insignificant whitespace).
// So, the following is illegal:
//
// string illegal =
//    """Test
//    string""";     // Will not compile! (we broke both of those rules)

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/raw-string-literal.md