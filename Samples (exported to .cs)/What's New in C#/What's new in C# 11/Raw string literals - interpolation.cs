// LINQPad Statements

// Just as with ordinary string literals, a leading $ sign enables string interpolation:

$"""The answer is {1 + 1}""".Dump ("The compiler interpolates {1 + 1}");

// Should you need to include braces in your string, the mechanism for doing so is different.
// Recall that with verbatim literals, you "escape" an interpolation with double braces: 

string verbatim = $@"{{
	""Thickness"" : {1 + 1}
}}";

// Raw string literals do not support escaping, but they let you change the interpolation sequence.
// Putting two $ signs before the string changes the interpolation sequence from single to double braces:

string raw = $$"""
	{
		"Thickness" : {{1 + 1}}
	}
	""";

Util.SyntaxColorText (raw, SyntaxLanguageStyle.Json).Dump ("Interpolated raw string literal");
(raw == verbatim).Dump ("Raw string literal matches verbatim string literal");

// Should you need to include double braces in your string, you can use triple $ signs (or more).
// In the following example, we use five $ signs, which lets us include up to four consecutive
// braces in the string:

raw = $$$$$"""
	<Test>
		<FourBraces>{{{{</FourBraces>
		<Interpolation>{{{{{1 + 1}}}}}</Interpolation>
	</Test>
	""";

Util.SyntaxColorText (raw, SyntaxLanguageStyle.XML).Dump ("Four braces in string");

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/raw-string-literal.md