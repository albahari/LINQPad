// LINQPad Statements

using System.Collections.Immutable

// In C# 13, you can use the params modifier not just with arrays, but other collection types, too:

Params1 ("one", "two", "three");
Params2 ("one", "two", "three");
Params3 ("one", "two", "three");

void Params1 (params IEnumerable<string> words) => words.Dump();
void Params2 (params List<string> words) => words.Dump();
void Params3 (params ImmutableArray<string> words) => words.Dump();

// More info:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/params-collections