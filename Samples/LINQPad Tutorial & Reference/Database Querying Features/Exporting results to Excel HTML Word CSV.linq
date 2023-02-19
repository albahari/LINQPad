<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

/* There are a number of ways to export results.

With rich-text queries, click the Export button on the right above the results. This gives options
for exporting to Word/Excel with/without formatting, and also to HTML.

In data-grid mode, right-click the grid. This gives options for exporting to Excel, CSV and HTML.

You can also export to CSV programmatically by calling Util.WriteCSV or Util.ToCsvString.
This works for non-database queries, too. For example:  */

var customers = new[]
{
	new { Name = "Jane", City = "Washington", LastUpdated = DateTime.Now },
	new { Name = "Dave", City = "New York", LastUpdated = DateTime.Now },
};

Util.ToCsvString (customers).Dump ("Util.ToCsvString Demo");

string tempFileName = Path.GetTempFileName().Dump ("Temp filename");
Util.WriteCsv (customers, tempFileName);

File.ReadAllText (tempFileName).Dump ("File content");