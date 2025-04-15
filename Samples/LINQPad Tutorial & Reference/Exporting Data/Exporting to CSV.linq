<Query Kind="Statements">
  <Namespace>System.Dynamic</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// To export data to CSV, just call Util.ToCsvString or Util.WriteCsv:

var customers = new[]
{
	new { Name = "Jane", City = "Washington", LastUpdated = DateTime.Now },
	new { Name = "Dave", City = "New York", LastUpdated = DateTime.Now },
};

Util.ToCsvString (customers).Dump ("Util.ToCsvString Demo");

Util.WriteCsv (customers, "data.csv");
File.ReadAllText ("data.csv").Dump ("File content");

// You can also tell these methods to include just specific columns:
Util.ToCsvString (TimeZoneInfo.GetSystemTimeZones().Take(10), "Id", "StandardName").Dump ("Specific columns");

// Projecting into an anonymous type does the same job.

// Expandos are also supported, if cast to IEnumerable<IDictionary<string, object>>.
