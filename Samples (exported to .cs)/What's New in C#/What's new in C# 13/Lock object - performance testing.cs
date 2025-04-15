// LINQPad Program

// .NET 9's new Lock class is roughly 1-2ns faster than the old Monitor.Enter / Monitor.Exit.

object oldLock = new();
Lock newLock = new();
int x;

void Main()
{
}

// To performance-test, highlight the following two methods and press Ctrl+Shift+B or ⌘⇧B to benchmark:

void TestOldLock()
{
	lock (oldLock)
		x++;
}

void TestNewLock()
{
	lock (newLock)
		x++;
}
