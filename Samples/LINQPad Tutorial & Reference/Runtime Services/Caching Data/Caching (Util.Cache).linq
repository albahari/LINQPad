<Query Kind="Statements" />

// You can cache data between executions with Util.Cache:	
var expensiveValue = Util.Cache (ExpensiveValue, "someKey");
expensiveValue.Dump();

// If you don't specify a cache key, LINQPad will infer it from the type.
// To clear the cache, kill the process (Script | Kill Process or Ctrl+Shift+F5 / Shift-Command-F5).

int ExpensiveValue()
{
	Thread.Sleep(3000);
	return 123;
}

// Here's the same thing with a lambda expression
expensiveValue = Util.Cache (() => { Thread.Sleep (3000); return 123; }, "someOtherKey");
expensiveValue.Dump();

// You can optionally specify a time-to-live (after which the cache entry will expire).
// The TTL excludes fetch time, and is ignored when the item's already in the cache.