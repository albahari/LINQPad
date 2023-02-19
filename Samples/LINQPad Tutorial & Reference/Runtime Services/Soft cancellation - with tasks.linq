<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

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