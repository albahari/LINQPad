// LINQPad Program

// Fields (or properties) can reuse primary constructor parameter names: 

class Person (string firstName, string lastName)
{
	readonly string firstName = firstName;
	readonly string lastName = lastName;

	public void Print() => Console.WriteLine (firstName + " " + lastName);
}

// In this scenario, the field or property takes precedence, thereby masking the primary
// constructor parameter - except on the righthand side of field and property initializers.

void Main()
{
	Person p = new Person ("Alice", "Jones");
	p.Print();
}

