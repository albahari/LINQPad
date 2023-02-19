// LINQPad Statements

// Structs can now define a parameterless constructor, and include field initializers.
new Person().Dump ("Calling parameterless ctor");

// Note that the constructor and field initializers are bypassed if the constructor isn't explicitly called:
default(Person).Dump ("default");
new Person[10].Dump ("array whose elements are not explicitly initialized");
new Container().Dump ("uninitialized field in a class");

// Parameterless constructors and field initializers are most useful on record structs.

struct Person
{
	public string FirstName = "<first-name>";   // Legal
	public string LastName;
	
	public Person()   // Legal
	{
		LastName = "<last-name>";
	}
}

class Container
{
	public Person SomePerson;
}

// More https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/parameterless-struct-constructors.md