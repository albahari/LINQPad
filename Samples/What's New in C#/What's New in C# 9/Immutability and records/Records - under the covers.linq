<Query Kind="Statements" />

// To enable non-destructive mutation, C# 9 automatically defines a protected 'copy constructor'
// which copies the underlying fields from another record.
//
// C# also overrides/overloads the equality functions and overrides ToString().
//
// You can see exactly what the compiler does under the covers by looking at it in ILSpy:

Util.OpenILSpy (typeof (Person));

public record Person
{
	public string FirstName { get; init; }
	public string LastName { get; init; }

	// If you prefer, you can write the 'copy constructor' yourself (uncomment the line below:)
	// protected Person (Person other) => (FirstName, LastName) = (other.FirstName, other.LastName);
}

