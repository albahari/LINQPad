<Query Kind="Statements" />

string greeting = "Hello, world";
HelloWorld();

// Top-level statements can be followed by methods.
// These methods can access variables declared by the top-level statements, making them *local methods*
// (so they cannot be overloaded):

void HelloWorld() => greeting.Dump();

// (Again, you've been able to do this LINQPad for some time.)
//
// What's more useful is that top-level statements in C# 9 can also be followed by type and namespace declarations:

class Foo
{
	public Foo()
	{		
	}
}

namespace Test
{
	class Foo
	{		
	}	
}

// Notice that we're still in 'C# Statements' mode in LINQPad.