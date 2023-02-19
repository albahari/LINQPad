// LINQPad Program

// From C# 11, you no longer need to explicitly populate every field in a struct's constructor.

void Main()
{
	new Foo().Dump();
}

struct Foo
{
	public int X, Y;
	
	public Foo()
	{
		// We no longer need to assign X and Y - the compiler initializes these fields for us.
	}
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/auto-default-structs.md