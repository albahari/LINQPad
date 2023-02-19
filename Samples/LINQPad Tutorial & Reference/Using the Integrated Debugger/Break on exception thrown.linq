<Query Kind="Statements" />

// Click the blue bug to break upon encountering *any* exception (whether handled or not).
// In this example, the blue bug will break, but the red bug will not.

Foo();

void Foo() 
{
	try
	{
		Bar();
	}
	catch { }
}

void Bar() => throw new InvalidOperationException ("Error");