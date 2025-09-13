// LINQPad Expression

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