// LINQPad Statements

// You can customize equality by writing a strongly-typed Equals method:

var person1 = new Person { FirstName = "Joe", LastName = "Bloggs" };
var person2 = new Person { FirstName = "JOE", LastName = "BLOGGS" };

person1.Equals (person2).Dump();   // True
(person1 == person2).Dump();       // True

public record Person
{
	public string FirstName { get; init; }
	public string LastName { get; init; }

	// Note the signature (virtual rather than override, and Person rather than object):	
	public virtual bool Equals (Person other) =>
		string.Equals (FirstName, other.FirstName, StringComparison.CurrentCultureIgnoreCase) &&
		string.Equals (LastName, other.LastName, StringComparison.CurrentCultureIgnoreCase);

	// Overriding GetHashCode is the same as with a class or struct:
	public override int GetHashCode() => (FirstName.ToUpper(), LastName.ToUpper()).GetHashCode();
}