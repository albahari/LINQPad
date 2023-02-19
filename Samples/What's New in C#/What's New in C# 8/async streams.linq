<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// With yield return, you can write an iterator; with await, you can write an asynchronous function.
// Asynchronous streams (from C# 8) combine these concepts and let you write an iterator that awaits,
// yielding elements asynchronously.

async Task Main()
{	
	await foreach (var number in RangeAsync (0, 10))
		Console.WriteLine (number);

	// In LINQPad, you can also just dump the IAsyncEnumerable.
	RangeAsync (0, 10).Dump();
}

// Support for asyncronous streams builds on the IAsyncEnumerable interface, which is an asynchronous
// counterparts to the IEnumerable interface.

public static async IAsyncEnumerable<int> RangeAsync (int start, int count)
{
	for (int i = start; i < start + count; i++)
	{
		await Task.Delay (100);
		yield return i;
	}
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#asynchronous-streams