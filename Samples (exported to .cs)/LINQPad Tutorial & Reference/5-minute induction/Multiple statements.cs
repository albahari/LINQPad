// LINQPad Statements

// Setting the script language to "C# Statement(s)" permits multiple statements:

var words =
	from word in "The quick brown fox jumps over the lazy dog".Split()
	orderby word.ToUpper()
	select word;
	
var duplicates =
	from word in words
	group word.ToUpper() by word.ToUpper() into g
	where g.Count() > 1
	select new { g.Key, Count = g.Count() };
	
var newGuid = Guid.NewGuid();	
	
// The Dump extension method writes out queries:

words.Dump();
duplicates.Dump();
newGuid.Dump();

// Notice that we do need semicolons now!