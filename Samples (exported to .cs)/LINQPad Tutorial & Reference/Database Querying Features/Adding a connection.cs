// LINQPad Expression

/* To add a connection, click 'Add connection' in the Schema Explorer TreeView on the top left.

The first step is to choose a driver. There are two types:

	BUILD DATA CONTEXT AUTOMATICALLY	
		LINQPad reads the schema from the database and generates backing classes for you automatically.
		You can choose between LINQ-to-SQL and Entity Framework Core (EF Core) for your back-end.
			- LINQ-to-SQL is specialized for SQL Server.
			- EF Core supports SQL Server, Oracle, MySQL, Postgres and SQLite.
			
	USE A TYPED DATA CONTEXT FROM YOUR OWN ASSEMBLY
		You already have a .DLL that you've built in Visual Studio that contains an EF Core data context.
		
LINQPad includes built-in drivers for LINQ-to-SQL and EF Core. There are also third-party drivers for querying
other data sources such as Azure Table Storage, CSV, and MongoDb - click 'View more drivers' to see.

TIP: LINQPad's LINQ-to-SQL is a specially enhanced version that supports most features of EF Core, plus some extra:
	- ExecuteUpdate/ExecuteDelete (for set-based updates/deletes that execute in a single round-trip)
	- TagWith() and TagWithCallSite() methods
	- string.Join over a grouping or sub-collection
	- Support for DateOnly/TimeOnly, spatial, hierarchyid, JSON and Vector column types
	- Support for following additional query operators:
	 	- Order / OrderDescending
		- Last / LastOrDefault / Reverse (on an ordered sequence)
		- LeftJoin / RightJoin / FullJoin
		- MinBy / MaxBy
		- DistinctBy / UnionBy
		- ExceptBy / IntersectBy
		- CountBy
		- ElementAt / ElementAtOrDefault
		- Shuffle (translated to ORDER BY NEWID())
	 
*/