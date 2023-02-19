// LINQPad Statements

// Util.Merge is handy when you want to add extra columns to the output of a LINQ query:

var withMerge =
	from il in InvoiceLines.Take (5)
	select Util.Merge (
	 	il,
		new { il.Invoice.InvoiceDate, il.Track.Composer });

// Without Util.Merge, the output doesn't look so nice (unless you explicitly select every column of InvoiceLine):

var withoutMerge =
	from il in InvoiceLines.Take (5)
	select new
	{
		il,
		il.Invoice.InvoiceDate,
		il.Track.Composer
	};
 
 withMerge.Dump ("With Util.Merge");
 withoutMerge.Dump ("Without Util.Merge");