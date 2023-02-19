<Query Kind="Statements" />

// A record is a special kind of class that’s designed to work well with immutable (read-only) data.
// Its most useful feature is non-destructive mutation:

var person = new Person { FirstName = "Joe", LastName = "Bloggs" };

// The 'with' keyword performs non-destructive mutation:
var otherPerson = person with { FirstName = "Josephine" };

// otherPerson is a new record; we haven't altered the original person.	
new { person, otherPerson }.Dump();

public record Person
{
	public string FirstName { get; init; }   // Init-only property
	public string LastName { get; init; }    // Init-only property
}