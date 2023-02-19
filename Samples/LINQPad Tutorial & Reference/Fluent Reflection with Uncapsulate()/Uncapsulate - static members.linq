<Query Kind="Statements" />

// To invoke a static member on a type, use the Uncapsulate static function:
Uncapsulate<Demo>()._privateField.Dump();

// If the type that you want to access is private, you can specify the type name as a string:
Uncapsulate ("Demo")._privateField.Dump();

// Use the + symbol to denote a nested class:
Uncapsulate ("Demo+NestedPrivate")._privateField.Dump();

// If the containing class is accessible, you can also do this:
Uncapsulate<Demo>().NestedPrivate._privateField.Dump();

// The class can live anywhere in the assemblies that your query references - including the .NET Core assemblies.
// Don't forget to prefix the type with its namespace:
StringBuilder cachedStringBuilder = Uncapsulate ("System.Text.StringBuilderCache").Acquire();

// Should the same type name exist in multiple assemblies (unlikely, but it can happen with private types),
// you can specify a simple assembly name to disambiguate:
var anotherSB = Uncapsulate ("System.Text.StringBuilderCache", "System.Private.CoreLib").Acquire();

// Note that you can call Dump on an uncapsulated type - this will dump its static fields and properties:
Uncapsulate ("System.SR").Dump();

class Demo
{
	static string _privateField = "static private value";

	class NestedPrivate
	{
		static string _privateField = "static private nested value";
	}	
}