<Query Kind="SQL">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
  <Namespace>System.Net</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

/*  LINQPad's coding agent works with SQL queries, too.

Be sure to enable "Include Connection Schema" if you want the agent to know about
table, view and column schemas.

Here are examples of the kinds of things you can ask it:
    Write a SQL query to...
    Explain what this SQL does
    Optimize this SQL query
    Insert sample data into this database
	Convert this Oracle SQL to SQLite SQL
    Add a foreign key constraint for Customers & Orders
    Suggest indexes to improve this query's performance

The model knows what provider you are using (SQL Server, PostgreSQL, MySQL, Oracle or SQLite).

With the client/server databases, you can ask it things like:
    Define a trigger on the PriceHistory table to prevent overlapping entries
    Show table sizes in MB
    Generate a detailed permissions report for this database
    Analyze table statistics for the Customers table
    Rebuild statistics on all tables
    Show current locks and blocking sessions

Demo: Press Ctrl+I / Command-I and enable "Include Connection Schema".
Ask it this:

	Enhance this query with a bunch of joins and a CTE   */

select ar.*, al.*
	FROM Artist ar
    JOIN Album al ON ar.ArtistId = al.ArtistId