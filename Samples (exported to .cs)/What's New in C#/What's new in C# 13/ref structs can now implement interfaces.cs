// LINQPad Statements

// ref structs can now implement interfaces:
// (this feature requires .NET 9+)

var foo = new Foo ("Test");
Print (foo);

// Note that the following line is illegal - we can't convert foo to IPrintable because ref structs cannot be boxed.
// IPrintable ip = foo;

// However, we can access the interface via a type parameter, if the new 'allows ref struct' constraint is specified:

void Print<T> (T value) where T : IPrintable, allows ref struct
{
	value.Print();
}

ref struct Foo : IPrintable
{
	public string Content;
	public Foo (string content) => Content = content;
	
	public void Print () => Content.Dump();
}

interface IPrintable
{
	void Print();
}
