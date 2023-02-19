<Query Kind="Statements" />

var test = new Test();
if (test?.TryParse ("123", out var number) ?? false)
{
	// In C# 9, this used to generate a compile-time error: "Use of unassigned local variable 'number'"
	number.Dump();
}

class Test
{
	public bool TryParse (string s, out int result)
		=> int.TryParse (s, out result);
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/improved-definite-assignment.md