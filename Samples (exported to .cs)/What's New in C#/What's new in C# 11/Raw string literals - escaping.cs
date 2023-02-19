// LINQPad Statements

using System.Globalization

// Raw string literals do not support traditional escaping.
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