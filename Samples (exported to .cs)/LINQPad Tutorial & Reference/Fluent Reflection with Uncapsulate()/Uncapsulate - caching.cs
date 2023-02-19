// LINQPad Statements

Demo demo = new Demo();

// If you repeatedly call the same method with the same argument types, the underlying
// reflection operations (including overload resolution) are cached.

// This caching works as long as you re-use the same uncapsulated instance:

Time (Slow).Dump ("Slow: calling Uncapsulate over and over");
Time (Fast).Dump ("Fast: calling Uncapsulate just once");

// If you need to eat your cake and have it, call Uncapsulate with useGlobalCache:true
Time (AlsoFast).Dump ("Fast: calling Uncapsulate with useGlobalCache:true");

// The static cache can be cleared to release memory and allow ALCs to unload:
LINQPad.Uncapsulator.Extensions.ClearCache();

void Slow()    // Calling Uncapsulate over and over will clear the cache
{
	for (int i = 0; i < 100000; i++)
		demo.Uncapsulate().SomeMethodCall (i, "test", DateTime.Now);
}

void Fast()    // Calling Uncapsulate just once means the cache will work
{
	var uncap = demo.Uncapsulate();
	
	for (int i = 0; i < 100000; i++)
		uncap.SomeMethodCall (i, "test", DateTime.Now);
}

void AlsoFast()    // Always caches if you call Uncapsulate (useGlobalCache:true)
{
	for (int i = 0; i < 100000; i++)
		demo.Uncapsulate (true).SomeMethodCall (i, "test", DateTime.Now);
}

TimeSpan Time (Action a)
{
	var sw = Stopwatch.StartNew();
	a();
	return sw.Elapsed;
}

class Demo
{
	void SomeMethodCall (int x, string s, DateTime d) { }
	void SomeMethodCall (string x, string s, DateTime d) { }
	void SomeMethodCall (char x, string s, DateTime d) { }
	void SomeMethodCall (int x, string s, TimeSpan ts) { }
	void SomeMethodCall (bool x, string s, DateTime d) { }
	void SomeMethodCall<T> (bool x, T s, DateTime d) { }
	void SomeMethodCall (ref bool x, string s, DateTime d) { }
}
