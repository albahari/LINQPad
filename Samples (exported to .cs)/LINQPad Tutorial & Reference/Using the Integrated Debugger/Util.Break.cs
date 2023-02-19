// LINQPad Statements

// You can programmatically ask the integrated debugger to break with Util.Break

var query =
	from word in "the quick brown fox jumps over the lazy dog".Split()
	select new { word, capitalized = Capitalize (word) };
	
query.Dump();

string Capitalize (string word) 
{
	if (string.IsNullOrEmpty (word)) return word;
	
	if (word == "brown") Util.Break();
	
	return char.ToUpper (word[0]) + word.Substring (1);
}