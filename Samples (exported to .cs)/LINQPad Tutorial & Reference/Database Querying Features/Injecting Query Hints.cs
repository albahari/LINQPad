// LINQPad Statements

/* The LINQ-to-SQL driver lets you inject SQL query hints via the special .WithQueryHints extension method:

Customers
	.Where (...)
	.WithQueryHints ("OPTIMIZE FOR UNKNOWN")
	.Dump();

The output SQL then looks like this:

SELECT ...
FROM [Customer] AS [t0]
WHERE ...
OPTION (OPTIMIZE FOR UNKNOWN)

Here's a list of all query hints:
https://learn.microsoft.com/en-us/sql/t-sql/queries/hints-transact-sql-query?view=sql-server-ver16

 */
