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
  <Namespace>System.Net</Namespace>
</Query>

/* You can get the coding agent to fix compile-time and runtime errors just by asking it.
Alternatively, click "Fix with AI" when an error appears, or press Ctrl+Shift+I / Command-Shift-I.

This brings up the coding agent with the prompt "Explain/fix the error".

DEMO: run the following script. You'll get a tricky runtime error!
Then ask the agent to fix it! (You'll get better results with thinking enabled.)  */

// 🎵 Music Store Dashboard 🎵

// Top 10 Best-Selling Artists
var topArtists = Artists
	.Select (a => new
	{
		a.Name,
		TracksSold = a.Albums.SelectMany (al => al.Tracks).SelectMany (t => t.InvoiceLines).Sum (il => il.Quantity),
		Revenue = a.Albums.SelectMany (al => al.Tracks).SelectMany (t => t.InvoiceLines).Sum (il => il.Quantity * il.UnitPrice)
	})
	.OrderByDescending (x => x.Revenue)
	.Take (10)
	.ToList();

topArtists.Dump().Chart (a => a.Name, a => a.Revenue, Util.SeriesType.Bar).Dump ("💰 Top 10 Artists by Revenue");

// Sales Over Time
var monthlySales = Invoices
	.GroupBy (i => new { i.InvoiceDate.Year, i.InvoiceDate.Month })
	.Select (g => new
	{
		Period = $"{g.Key.Year}-{g.Key.Month:D2}",
		Orders = g.Count(),
		Revenue = g.Sum (i => i.Total)
	})
	.OrderBy (x => x.Period)
	.ToList();

monthlySales.Dump().Chart (s => s.Period, s => s.Revenue, Util.SeriesType.SplineArea).Dump ("📈 Monthly Revenue Trend");

// Top Customers with Highlighting
var vipCustomers = Customers
	.Select (c => new
	{
		Customer = $"{c.FirstName} {c.LastName}",
		c.Country,
		TotalSpent = c.Invoices.Sum (i => i.Total),
		Orders = c.Invoices.Count
	})
	.OrderByDescending (x => x.TotalSpent)
	.Take (10)
	.AsEnumerable()
	.Select (c => new
	{
		Customer = Util.HighlightIf (c.TotalSpent > 40, c.Customer),
		c.Country,
		TotalSpent = c.TotalSpent,
		c.Orders,
		AvgOrderValue = Math.Round (c.TotalSpent / c.Orders, 2)
	});

vipCustomers.Dump ("🌟 VIP Customers (highlighted if spent > $40)");

// Longest Tracks by Genre
var epicTracks = Tracks
	.OrderByDescending (t => t.Milliseconds)
	.Take (5)
	.Select (t => new
	{
		t.Name,
		Artist = t.Album.Artist.Name,
		Album = t.Album.Title,
		Duration = TimeSpan.FromMilliseconds (t.Milliseconds).ToString (@"mm\:ss"),
		Genre = t.Genre.Name
	});

epicTracks.Dump ("⏱️ Longest Tracks");

// Fun Fact
var totalMusic = TimeSpan.FromMilliseconds (Tracks.Sum (t => t.Milliseconds));
Util.Highlight ($"🎶 Total music in library: {totalMusic.Days} days, {totalMusic.Hours} hours, {totalMusic.Minutes} minutes!").Dump();

