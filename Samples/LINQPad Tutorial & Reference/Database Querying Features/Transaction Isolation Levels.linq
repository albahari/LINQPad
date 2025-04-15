<Query Kind="Statements" />

/* You can set a transaction isolation level via the dropdown in the toolbar.

This works for queries that use LINQ-to-SQL or EF Core connections
It can also work with third-party drivers that implement this feature.

This feature does not require a transaction, and works by automatically 
issuing a SET TRANSACTION ISOLATION LEVEL command immediately after 
LINQ-to-SQL or EF Core opens a connection.

(Working without a transaction in the read-committed or snapshot isolation 
levels is useful for querying a database without blocking updates.)

You can also set a per-connection default by right-clicking the combo,
and set/override the isolation level programmatically via the
Util.TransactionIsolationLevel property. */

Util.TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;