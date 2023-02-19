<Query Kind="Statements" />

// C#'s foreach loop requires that the type being enumerating expose a 'GetEnumerator' method.
// From C# 9, that method can be an extension method:

foreach (int i in 10)
	i.Dump();
	
static class Extensions
{
	public static IEnumerator<int> GetEnumerator (this int x) =>
		Enumerable.Range (0, x).GetEnumerator();
}