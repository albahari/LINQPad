// LINQPad Statements

// The fluent AddYSeries method also lets you provide the y-data in separate IEnumerables:

string[] xSeries = { "Jan", "Feb", "Mar", "Apr", "May" };
int[] totalOrders = { 100, 120, 140, 130, 145 };
int[] pendingOrders = { 50, 70, 60, 90, 10 };

xSeries.Chart()
  .AddYSeries (totalOrders,   name:"Total Orders")
  .AddYSeries (pendingOrders, name:"Pending Orders")
  .Dump();