// LINQPad Statements

// You can optionally specify a series type such as Pie, Area, Spline, etc:

var customers = new[]
{
	new { Name = "John", TotalOrders = 100 },
	new { Name = "Mary", TotalOrders = 130 },
	new { Name = "Sara", TotalOrders = 140 },
	new { Name = "Paul", TotalOrders = 125 },
};

customers.Chart (c => c.Name, c => c.TotalOrders, Util.SeriesType.Area).Dump();