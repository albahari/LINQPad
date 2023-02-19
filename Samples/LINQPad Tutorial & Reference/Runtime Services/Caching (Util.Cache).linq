<Query Kind="Statements" />

// You can cache data between queries with Util.Cache:	
var expensiveValue = Util.Cache (ExpensiveValue, "someKey");
expensiveValue.Dump();

// If you don't specify a cache key, LINQPad will infer it from the type.
// To clear the cache, kill the process (Query | Kill Process or Ctrl+Shift+F5).

int ExpensiveValue()
{
	Thread.Sleep(5000);
	return 123;
}