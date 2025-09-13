<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

// The 'field' keyword in C# 14 lets you access a property's underlying field in an automatic property.

void Main()
{
	Name = "Joe";
	Name = " ";	
}

public string Name
{
	get;
	set => field = !string.IsNullOrWhiteSpace (value)
		? value
		: throw new ArgumentOutOfRangeException (nameof (Name), "This property must not be null, empty or whitespace");
}

// More info:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/field