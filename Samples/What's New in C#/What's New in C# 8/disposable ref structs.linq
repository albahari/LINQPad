<Query Kind="Program" />

// ref structs cannot be boxed, and so cannot implement interfaces.

void Main()
{
	// The following line will not compile:
	// object foo = new Foo();
	
	// However, we can still apply the using statement if the struct has a Dispose() method:
	using (new Foo())
	{
		///
	}
}

ref struct Foo  // Cannot implement any interfaces
{
	public int X, Y;
	
	public void Dispose()
	{
		"Dispose".Dump();
	}
}
