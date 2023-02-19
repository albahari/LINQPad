<Query Kind="Statements" />

// With the fluent AddYSeries method, you can plot multiple y-series on the same chart, and give each a name:

var customers = new[]
{
	new { Name = "John", TotalOrders = 100, PendingOrders = 50, CanceledOrders = 20 },
	new { Name = "Mary", TotalOrders = 130, PendingOrders = 70, CanceledOrders = 25 },
	new { Name = "Sara", TotalOrders = 140, PendingOrders = 60, CanceledOrders = 17 },
};

customers.Chart (c => c.Name)
	.AddYSeries (c => c.TotalOrders,    name:"Total")
	.AddYSeries (c => c.PendingOrders,  name:"Pending")
	.AddYSeries (c => c.CanceledOrders, name:"Canceled")
	.Dump();
