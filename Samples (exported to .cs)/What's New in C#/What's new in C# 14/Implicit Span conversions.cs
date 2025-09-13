// LINQPad Program

// C# 14 handles implicit conversions between ReadOnlySpan<T>/Span<T> and T[] in scenarios such as the following:

void Main()
{
	int[] numbers = {1, 2, 3};
	bool answer = numbers.StartsWith (1);   // Does not compile under C# 13 and earlier
	answer.Dump();
}

static class Extensions
{
	public static bool StartsWith<T> (this ReadOnlySpan<T> span, T value) where T : IEquatable<T>
		=> span.Length != 0 && EqualityComparer<T>.Default.Equals (span [0], value);
}

// More info:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/first-class-span-types