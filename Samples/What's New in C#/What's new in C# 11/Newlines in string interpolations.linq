<Query Kind="Statements" />

// In C# 11, the interpolated parts of interpolated strings can span multiple lines:

$"Number {
	2 +
	2 }".Dump();     // Illegal before C# 11

// Prior to C# 11, this worked only with verbatim strings (@"..."):

@$"Number {
	2 +
	2 }".Dump();
	
// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/new-line-in-interpolation.md