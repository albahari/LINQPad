<Query Kind="Statements" />

// You can now apply attributes to local functions.

Foo();

// Because methods that follow top-level statements are *local methods*,
// this feature may get some use.

[MyAttribute]                    // Illegal prior to C# 9
void Foo() => "Foo".Dump();

class MyAttribute : Attribute { }

class AnotherDemo
{
	void Foo()
	{
		[MyAttribute]
		void Local()      // Another example of a local function
		{			
		}
	}
}