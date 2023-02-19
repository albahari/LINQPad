<Query Kind="Statements" />

// A query that monitors QueryCancelToken can take as long as it likes to clean up.
// If it refuses to end, you can press Stop again to force a hard-cancel.

while (true)
{
	if (QueryCancelToken.IsCancellationRequested)
	{
		"I'm not going to end!".Dump();
		Thread.Sleep (Timeout.Infinite);
	}
	Thread.Sleep(10);
}