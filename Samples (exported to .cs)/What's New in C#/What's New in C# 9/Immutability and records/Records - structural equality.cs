// LINQPad Statements

// Records get structural equality by default (like structs, tuples and anonymous types).

var person1 = new Person { FirstName = "Joe", LastName = "Bloggs" };
var person2 = new Person { FirstName = "Joe", LastName = "Bloggs" };
person1.Equals (person2).Dump();   // True

// C# also overrides == and != operators:
(person1 == person2).Dump();   // True

public record Person
{
	public string FirstName { get; init; }
	public string LastName { get; init; }
}