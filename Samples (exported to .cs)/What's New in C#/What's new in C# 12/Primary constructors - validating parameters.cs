// LINQPad Program

// You can validate a primary constructor parameter upon construction using a
// field or property initializer:

class Person (string firstName, string lastName)
{
	readonly string lastName = (lastName == null)
	   ? throw new ArgumentNullException ("lastName")
	   : lastName;
}

void Main()
{
	new Person ("Alice", null);   // throws ArgumentNullException
}

