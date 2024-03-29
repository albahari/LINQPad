// LINQPad Statements

using System.Threading.Tasks

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

// You can also dump IAsyncEnumerables to Data Grids:
// click the "Results to Data Grids" toolbar button, or call .Dump(true).