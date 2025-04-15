// LINQPad Program

// Primary constructors help you quickly create classes or structs for prototyping and other simple scenarios.
// To use this feature, include a parameter directly after a class (or struct) declaration:

class Person (string firstName, string lastName)
{
	// This instructs the compiler to generate a primary constructor with the parameters firstName and lastName.
	// Unlike with ordinary constructors, these parameters do not disappear out of scope when the constructor 
	// finishes executing - they remain in scope and can be subsequently accessed from anywhere within the
	// class - for the life of the object:
	public void Print() => Console.WriteLine (firstName + " " + lastName);
}

void Main()
{
	Person p = new Person ("Alice", "Jones");
	p.Print();    // Alice Jones
}

// Unlike with records, the compiler doesn't automatically back each parameter with a public property, so the
// parameters remain private.

// Also note that a primary constructor parameter is not a *field* - it's a special C# construct.
// However, the compiler may choose to generate a hidden field in the underlying implementation
// to store its value if required.

