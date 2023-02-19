<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// The following demonstrates async/await in "C# Program" mode.
// Notice that the Main method returns a Task. This allows LINQPad to know when your query is complete.

async Task Main()
{
	"Starting".Dump();	
	int result = await Foo();
	result.Dump();	
	"Finished".Dump();
}

async Task<int> Foo()
{
	await Task.Delay (3000);
	return 42;
}
