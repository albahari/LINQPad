<Query Kind="Expression" />

/* To add a connection, click the 'Add connection' hyperlink in the Schema Explorer TreeView on the left.

The first step is to choose a driver. There are two types:

	BUILD DATA CONTEXT AUTOMATICALLY	
		LINQPad reads the schema from the database and generates backing classes for you to query on the fly.
		You can choose between LINQ-to-SQL and Entity Framework Core (EF Core) for your back-end.
			LINQ-to-SQL is specialized for SQL Server
			EF Core supports SQL Server, Oracle, MySQL, Postgres and SQLite.
	
	USE A TYPED DATA CONTEXT FROM YOUR OWN ASSEMBLY
		You already have a .DLL that you've built in Visual Studio that contains an EF Core data context that
		you to query in LINQPad.
		
LINQPad includes built-in drivers for LINQ-to-SQL and EF Core. There are also third-party drivers for querying
other data sources such as Azure Table Storage, CSV, and MongoDb - click 'View more drivers' to see.

*/