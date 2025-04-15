<Query Kind="Program" />

// You can easily assign primary constructor parameters to read/write properties:

class Person (string firstName, string lastName)
{
	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; } = lastName;
}

// However, adding validation to these properties is not straightforward in that you must validate
// in two places: in a (manually implemented) property set accessor, and in the property initializer.
// At this point, it's easier to abandon the shortcut of primary constructors.

void Main()
{
	var p = new Person ("Alice", null);
	p.Dump();
}

// Another limitation of primary constructors is that you must accomplish all initialization through
// field and property initializers. You cannot add extra code to a primary constructor.