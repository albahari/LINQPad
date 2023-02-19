// LINQPad Statements

using System.Threading.Tasks

// Here's a more elaborate example of dumping a sequence of 10 tasks:
Enumerable.Range (0, 10).Select (i => Foo (i * 100, i)).Dump();

async Task<int> Foo (int delay, int result)
{
	await Task.Delay (delay);
	return result;
}