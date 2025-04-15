// LINQPad Statements

// You can create multiple sheets by calling the fluent .AddSheet method:

var collection1 = Enumerable.Range (0, 50).Select (i => new { Number = i, String = "This is a test" });
var collection2 = Enumerable.Range (0, 50).Select (i => new { Number = i, Date = DateTime.Now });
var collection3 = Enumerable.Range (0, 50).Select (i => new { Number = i, Bool = i % 2 == 1 });

collection1.ToSpreadsheet ("collection1")
	.AddSheet (collection2, "collection2")
	.AddSheet (collection3, "collection3")
	.Open();   // or .Save(...)

