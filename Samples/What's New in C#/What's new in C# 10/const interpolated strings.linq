<Query Kind="Statements" />

// In C# 10, string interpolations can include string interpolations.

const string language = "C# 10";
const string greeting = $"Hello from {language}.";
	
greeting.Dump();

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/constant_interpolated_strings.md