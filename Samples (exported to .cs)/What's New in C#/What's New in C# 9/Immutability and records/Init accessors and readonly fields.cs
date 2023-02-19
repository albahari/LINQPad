// LINQPad Statements

// Init-only accessors are allowed to mutate readonly fields:

var person = new Person { FirstName = "Joe", LastName = "Bloggs" }.Dump();

public class Person
{
	readonly string _firstName;
	readonly string _lastName;

	public string FirstName
	{
		get => _firstName;
		init => _firstName = value ?? throw new ArgumentNullException (nameof (FirstName));
	}
	
	public string LastName
	{
		get => _lastName;
		init => _lastName = value ?? throw new ArgumentNullException (nameof (LastName));
	}
}