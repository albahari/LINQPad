// LINQPad Statements

using System.Threading.Tasks

// Soft cancellation works just fine with tasks and async methods:

try
{
	await Task.Delay (Timeout.Infinite, QueryCancelToken);
}
finally
{
	EssentialCleanup();
}

void EssentialCleanup() => "Clean-up code".Dump();