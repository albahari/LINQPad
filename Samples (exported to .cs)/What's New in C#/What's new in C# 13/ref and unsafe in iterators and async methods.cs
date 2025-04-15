// LINQPad Statements

using System.Threading.Tasks

// Iterators and async methods can now use 'ref local' variables and include unsafe code,
// as long they are not accessed across an 'await' or 'yield return' boundary.

TestAsync().Dump();

async Task<string> TestAsync()
{
	int[] numbers = { 0, 1, 2, 3, 4 };
	ref int numRef = ref numbers [2];
	numRef.Dump();   // OK
	
	await Task.Delay (2000);
	
	// We can't access numRef here:
	// numRef.Dump();   // Not OK
	
	return "Done";
}