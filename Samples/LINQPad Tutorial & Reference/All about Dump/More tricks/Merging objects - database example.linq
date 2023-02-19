<Query Kind="Statements">
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
</Query>

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