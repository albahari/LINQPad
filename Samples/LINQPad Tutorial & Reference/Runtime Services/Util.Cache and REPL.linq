<Query Kind="Statements" />

// Caching data between executions provides the benefit of a REPL.
// In other words, you can execute new queries without recomputing previous values.

var expensiveValue = Util.Cache (ExpensiveValue, "someKey");  // Never have to compute this again.
expensiveValue.Dump();

// After executing the query, change the following function to something else (or add another line below).
// You won't need to wait another five seconds to fetch expensiveValue.
Math.Sqrt (expensiveValue).Dump();

int ExpensiveValue()
{
	Thread.Sleep(5000);
	return 123;
}