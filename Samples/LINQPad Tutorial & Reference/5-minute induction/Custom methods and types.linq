<Query Kind="Statements" />

// You can also write your own methods and classes:

MyMethod();	
new MyClass().GetHelloMessage().Dump();

void MyMethod()
{
	"LINQPad is the ultimate .NET code scratchpad!".Dump();
}

class MyClass
{
	public string GetHelloMessage() => 
		"Put an end to those hundreds of Visual Studio Console projects cluttering your source folder!";
}

// You can even define namespaces:
namespace Foo
{
	class Bar
	{		
	}
}

// To reference any extra assemblies, or to import namespaces, just press F4!
