<Query Kind="Program" />

// If you change the language dropdown in the toolbar to 'C# Program', LINQPad will add a Main() method.
// This enables a bunch of advanced features, such as the ability to define global (static) constants and methods:

public const string SomeConstant = "Put an end to those hundreds of Visual Studio Console projects cluttering your source folder!";
public static string SomeMethod (string input) => input.ToUpper();

void Main()
{
	new MyClass().GetHelloMessage().Dump();
}

class MyClass
{
	// We can access SomeConstant and SomeMethod here:
	public string GetHelloMessage() => SomeMethod (SomeConstant);
}

namespace Foo
{
	class Bar
	{		
		// You can also access SomeConstant and SomeMethod here
	}
}

// For a full description of what you can do in 'C# Program' mode, click the link below:
// query://../../What's_New_in_C#_9/Top-level_statements/LINQPad_note_-_C#_Statements_vs_C#_Program 
