// LINQPad Statements

using System.Threading.Tasks;

// Another useful pattern is to call Environment.Exit to end the process programmatically after cleaning up.
// This allows for cleanup without needing to monitor cancellation tokens.

ScriptCancelToken.Register (() =>
{
	// Perform cleanup:
	"Cleanup".Dump();
	
	// Now we can end the script's process
	Environment.Exit(0);
});

Task.Run (InfiniteLoop);    // Start a number of infinite loops
Task.Run (InfiniteLoop);
Task.Run (InfiniteLoop);
InfiniteLoop();

void InfiniteLoop()   // With this pattern, we don't need cancellation tokens everywhere.
{
	while (true)
	{
		Console.Write ("X");
		Thread.Sleep (500);
	}
}
