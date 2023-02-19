// LINQPad Statements

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