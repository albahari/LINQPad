<Query Kind="Statements" />

// In C# 9, you can declare a property with an 'init' accessor instead of a 'set' accessor.
// Init-only properties can be set via an object initializer, but are otherwise read-only:

var person = new CSharp9Person { FirstName = "Joe", LastName = "Bloggs" }.Dump();

// person.FirstName = "foo";    // Prohibited

public class CSharp9Person
{
	public string FirstName { get; init; }    // init-only 
	public string LastName { get; init; }     // init-only 
}

// Init-only properties allow you to have large immutable classes without resorting to
// the anti-pattern of writing a constructor that takes in dozens of optional parameters.
