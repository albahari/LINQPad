// LINQPad Statements

// Calling .Refresh forces the DumpContainer to refresh. Here's an example of when this is useful:

var list = Enumerable.Range (0, 10).ToList();
var dc = new DumpContainer (list).Dump ("The incredible shrinking list");

for (int i = 9; i > 0; i--)
{
	list.RemoveAt (i);
	dc.Refresh();          // Because we're not updating the Content property, we must call Refresh.

	Thread.Sleep(1000);
}
