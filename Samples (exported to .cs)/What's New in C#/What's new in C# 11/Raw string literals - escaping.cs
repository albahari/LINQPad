// LINQPad Statements

using System.Globalization

// If you need to represent three consecutive quotes in a raw string literal, use four
// quotes instead as a delimiter. You can use as many quotes as you like:

""""This includes """ three quotes"""".Dump();

// This feature liberates raw string literals from needing to support escape sequences.
// Raw string literals do not, in fact, support traditional escaping.
// The workaround is to use an interpolation:

const string clip = "\ud83d\udcce";
string nl = Environment.NewLine;

string message = $"""{clip}Only interpolations can escape{nl}raw string literals""";

Util.WithStyle (message, "font-size:20pt").Dump ("Message");

// In the following example, we use $$ to allow single braces to appear in the string:

const char tab = '\t';

string sourceCode = $$"""
	using System;

	class Program
	{
	{{tab}}static void Main() {}
	}
	""";

Util.SyntaxColorText (sourceCode, SyntaxLanguageStyle.CSharp).Dump ("Source code");