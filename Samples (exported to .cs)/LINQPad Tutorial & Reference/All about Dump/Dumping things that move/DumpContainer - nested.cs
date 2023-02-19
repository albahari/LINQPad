// LINQPad Statements

using System.Threading.Tasks

// You can dump many DumpContainers at a time.
// You can nest them in other objects - even in other DumpContainers.

Enumerable.Range (0, 3).Select (i => GetShrinkingDumpContainer()).Dump();

DumpContainer GetShrinkingDumpContainer()
{
	var list = Enumerable.Range (0, 5).ToList();
	var dc = new DumpContainer (list);
	Shrink();
	return dc;

	async void Shrink()
	{
		for (int i = 4; i > 0; i--)
		{
			list.RemoveAt (i);
			dc.Refresh();
			await Task.Delay (1000);
		}
	}
}