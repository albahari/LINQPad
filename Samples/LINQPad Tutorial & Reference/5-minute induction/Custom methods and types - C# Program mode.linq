<Query Kind="Program" />

// If you change the language dropdown in the toolbar to 'C# Program', LINQPad will add a Main() method.
// This breaks you free of the restrictions of top-level statements, unlocking all of LINQPad's power.

void Main()
{
	SayHello();
	SayHello ("Hello, world!");
	new MyClass().GetHelloMessage().Dump();
}

// Method overloading is permitted:
void SayHello() => "Hello, world".Dump();
void SayHello (string greeting) => greeting.Dump();

// Static members are also permitted. Static members can be accessed from inside classes (below)
public static string Shout (string input) => input.ToUpper();

class MyClass
{
	// We can access SomeMethod here:
	public string GetHelloMessage() => Shout ("Hello, world");
}

namespace Foo
{
	class Bar
	{		
		// You can also access SomeMethod here
	}
}

// For a full description of what you can do in 'C# Program' mode, click the link below:
// script://../../What's_New_in_C#/What's_New_in_C#_9/Top-level_statements/LINQPad_note_-_C#_Statements_vs_C#_Program 
