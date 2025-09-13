// LINQPad Program

using System.Threading.Tasks;

// Here's the preceding example in 'C# Program' mode

async Task Main()
{
	try
	{
		await Task.Delay (Timeout.Infinite, ScriptCancelToken);
	}
	finally
	{
		EssentialCleanup();
	}
}

void EssentialCleanup() => "Clean-up code".Dump();