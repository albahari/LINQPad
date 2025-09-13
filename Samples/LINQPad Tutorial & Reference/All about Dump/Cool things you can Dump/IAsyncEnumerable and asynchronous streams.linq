<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// LINQPad lets you directly dump IAsyncEnumerables.

// As with Tasks, calling Dump on an IAsyncEnumerable is asynchronous, so you can
// dump multiple sequences simultaneously:

RangeAsync (0, 10).Dump ("Async stream 1");
RangeAsync (0, 10).Dump ("Async stream 2");

async IAsyncEnumerable<int> RangeAsync (int start, int count)
{
	for (int i = start; i < start + count; i++)
	{
		await Task.Delay (200);
		yield return i;
	}
}

