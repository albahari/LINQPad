<Query Kind="Statements" />

// You can chart any sequence easily with the Chart() extension method.
//
// The simplest usage is to provide a lambda expression for the x-series, and another for the y-series:

var customers = new[]
{
	new { Name = "John", TotalOrders = 100 },
	new { Name = "Mary", TotalOrders = 130 },
	new { Name = "Sara", TotalOrders = 140 },
	new { Name = "Paul", TotalOrders = 125 },
};

customers.Chart (c => c.Name, c => c.TotalOrders).Dump();   // Don't forget to Dump it!