<Query Kind="Program" />

// Property patterns let you match against a property, such as State in this example:

void Main()
{
	var address = new Address { State = "WA" };
	ComputeSalesTax (address, 100).Dump();
}

static decimal ComputeSalesTax (Address location, decimal salePrice) =>
	location switch
	{
		{ State: "WA" } => salePrice * 0.06M,    // Property pattern
		{ State: "MN" } => salePrice * 0.75M,
		{ State: "MI" } => salePrice * 0.05M,
		_ => 0M
	};
	
class Address
{
	public string State;
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#property-patterns