<Query Kind="Program" />

// Records also support primary constructors:

record PersonRecord (string FirstName, string LastName)
{
	public void Print() => Console.WriteLine (FirstName + " " + LastName);
}

// With records, however, the compiler also generates a public init-only property for
// each primary constructor parameter (unless you define one yourself). Like this:

class PersonClass (string FirstName, string LastName)
{
	public string FirstName { get; init; } = FirstName;
	public string LastName { get; init; } = LastName;
}

// This means that with records, primary constructor parameters are always masked,
// either by an automatically generated property or a manually defined property.

void Main()
{
	var record = new PersonRecord ("Alice", "Jones").Dump();
	var @class = new PersonClass ("Alice", "Jones").Dump();

	// Records also support other features, such as nondestructive mutation ('with'):
	var record2 = record with { FirstName = "Brown" };
	
	// ... and stuctural equality:
	(record == new PersonRecord ("Alice", "Jones")).Dump ("Structural equality");   // True
	
	// ... and an automatic deconstructor:
	var (first, last) = record;
	
	// ... and an automatic ToString() override:
	record.ToString().Dump();
}

