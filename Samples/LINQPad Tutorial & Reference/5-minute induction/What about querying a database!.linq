<Query Kind="Expression">
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
</Query>

//	Knew you'd ask!
//
//	The following queries a built-in demo database. Give it a run!
//  (After running it, click the 'SQL' button below to see the translation to SQL.)

from a in Albums
let jazzTracks = a.Tracks.Where (t => t.Genre.Name == "Jazz")
where jazzTracks.Any()
orderby a.Artist.Name
select new
{
	AlbumTitle = a.Title,
	Artist = a.Artist.Name,
	JazzTracks = 
		from t in jazzTracks 
		select new { t.Name, t.UnitPrice, Media = t.MediaType.Name }
}

/*	To query your own databases, click 'Add connection' (on the TreeView to the left),
	then select the desired database in the script's "Connection" combo (above).
	
	LINQPad will then magically generate a typed data context behind the scenes.

	Database and connection details are saved with each script, so next time you
	open the script, the schema tree on the left will conveniently reappear.       */