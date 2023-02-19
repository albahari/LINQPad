<Query Kind="Statements" />

// You can highlight data with the Util.Highlight method. Don't forget to Dump the output:

Util.Highlight ("Hello").Dump();

// There's also a Util.HighlightIf method which highlights only if a condition is true.

Util.HighlightIf (2 > 1, "2 is greater than 1").Dump();

// Util.HighlightIf makes it easy to selectively highlight data in queries.
// The following query lists the files in the LINQPad folder, highlighting the executables:

var files =
	from file in new DirectoryInfo (Util.LINQPadFolder).GetFiles()
	select new
	{
		Name = Util.HighlightIf (file.Extension == ".exe", file.Name),
		file.Length,
		file.LastWriteTime
	};

files.Dump();