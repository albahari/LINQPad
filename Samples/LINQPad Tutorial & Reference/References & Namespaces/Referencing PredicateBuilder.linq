<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// LINQPad also includes PredicateBuilder - to use, simply press F4 and tick
// 'Include PredicateBuilder'. PredicateBuilder is a simple class for dynamically
// building query filter expressions. Here's an example using the chinook demo database:

var predicate = PredicateBuilder.False<Track>();

// Let's dynamically build a predicate that searches for all tracks that have a genre
// of "Metal" or "Heavy Metal", and that contain "Wild" in the title.
predicate = predicate.Or (c => c.Genre.Name == "Metal");
predicate = predicate.Or (c => c.Genre.Name == "Heavy Metal");
predicate = predicate.And (c => c.Name.Contains ("Wild"));

var query =
	from t in Tracks.Where (predicate)
	select new { t.Name, Genre = t.Genre.Name, Arist = t.Album.Artist.Name };

query.Dump();

// Go to http://www.albahari.com/expressions/ for more info on PredicateBuilder.