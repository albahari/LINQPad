<Query Kind="Statements" />

// Cache is also defined as an extension method on IEnumerable<T>
ExpensiveValues().Cache().Dump();

// This can be really useful when querying databases. 

IEnumerable<int> ExpensiveValues()
{
	for (int i = 0; i < 10; i++)
	{
		Thread.Sleep (500);
		yield return i;
	}
}