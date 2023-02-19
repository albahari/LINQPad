// LINQPad Expression

// You can highlight entire rows as follows:

from file in new DirectoryInfo (Util.LINQPadFolder).GetFiles()
select Util.HighlightIf (
	file.Extension == ".exe",
	new
	{
		file.Name,
		file.Length,
		file.LastWriteTime
	})
		
