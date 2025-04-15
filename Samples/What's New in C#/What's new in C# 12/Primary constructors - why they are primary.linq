<Query Kind="Program" />

// Primary constructors are called primary because any additional constructors that you
// choose to write must call it. This ensures that the primary constructor parameters
// are always populated.

class Person (string firstName, string lastName)
{
	public Person (string firstName, string lastName, int age)
		: this (firstName, lastName)    // We must call the primary constructor!
	{		
	}

	public void Print() => Console.WriteLine (firstName + " " + lastName);
}

void Main()
{
	Person p = new Person ("Alice", "Jones");
	p.Print();    // Alice Jones
}

