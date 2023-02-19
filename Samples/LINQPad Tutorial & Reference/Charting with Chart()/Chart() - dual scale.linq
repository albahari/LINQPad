<Query Kind="Statements" />

// Each y-series can have a different series type, and can be assigned to the secondary y-axis scale on the right.

var customers = new[]
{
	new { Name = "John", TotalOrders = 1000, PendingOrders = 50, CanceledOrders = 20 },
	new { Name = "Mary", TotalOrders = 1300, PendingOrders = 70, CanceledOrders = 25 },
	new { Name = "Sara", TotalOrders = 1400, PendingOrders = 60, CanceledOrders = 17 },
};

customers.Chart (c => c.Name)
	.AddYSeries (c => c.TotalOrders,    Util.SeriesType.Spline, "Total")
	.AddYSeries (c => c.PendingOrders,  Util.SeriesType.Column, "Pending",   useSecondaryYAxis:true)
	.AddYSeries (c => c.CanceledOrders, Util.SeriesType.Column, "Cancelled", useSecondaryYAxis:true)
	.Dump();