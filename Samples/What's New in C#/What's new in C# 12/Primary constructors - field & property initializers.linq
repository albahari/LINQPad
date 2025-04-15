<Query Kind="Program" />

// Primary constructor parameters can be accessed from field and property initializers,
// allowing you to assign their values to a field or property:

class Person (string firstName, string lastName)
{
	public readonly string FirstName = firstName;  // Field
	public string LastName { get; } = lastName;    // Property
}

void Main()
{
	Person p = new Person ("Alice", "Jones");
	p.Dump();
}

