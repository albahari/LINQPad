// LINQPad Program

// Click the red bug to break upon encountering an unhandled exception.

void Main()
{
	Foo();
}

void Foo() 
{
	Bar();
}

void Bar() => throw new InvalidOperationException ("Error");