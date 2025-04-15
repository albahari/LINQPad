<Query Kind="Program">
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

// ... which leads to the question, what can you do in LINQPad's 'C# Program' mode that you can't
// do in 'C# Statements' mode?
//
// First, you can declare static variables/constants/methods, which can be used unqualified
// anywhere in the script:

public const int CurrentScriptVersion = 5;
public static string Pascal (string s) => s == "" ? "" : char.ToUpper (s[1]) + s.Substring(2);

[DllImport ("shell32.dll", EntryPoint = "#680")]
public static extern bool IsUserAnAdmin();

class Foo
{
	// We can call Pascal here:
	public Foo() => Pascal ("test").Dump();
}

namespace Test
{
	class Foo
	{
		static int X => CurrentScriptVersion;       // we can see CurrentScriptVersion here
	}
}

void Main()       // Here's our entry point.
{
	// Notice that the scope of variables declared in the Main method doesn't bleed into other non-local methods.
	
	string greeting = "Hello, world";
	HelloWorld();
	
	// This is a local method, so it can access 'greeting'. But AnotherMethod (below) can't:
	void HelloWorld() => greeting.Dump();
}

void AnotherMethod()
{
	// We cannot access 'greeting'. But we can still access fields:
	_field.Dump();
}

int _field = 123;   // Instance field - can be accessed by Main() and AnotherMethod()

// Because methods declared here are ordinary methods and not local methods, we can overload them:
void AnotherMethod (string s) { }

// Another benefit of 'C# Program' mode is that we can declare up to 9 additional entry points:
void Main1() => "Main1".Dump();    // Press Alt+Shift+1 to run this
void Main2() => "Main2".Dump();    // Press Alt+Shift+2 to run this
void Main3() => "Main3".Dump();    // Press Alt+Shift+3 to run this

// Finally, 'C# Program' queries act as 'mini-libraries' when #load-ed from another script.
// In particular, anything in the 'Main' method is treated as test code and ignored when the query is #load-ed,
// and queries can define 'hook methods' for additional flexibility (see https://www.linqpad.net/LinqReference.aspx)