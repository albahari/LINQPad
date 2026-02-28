// LINQPad Statements

// You can specify a color as an HTML-style string:

Util.Highlight ("Hello", "#dfd").Dump();

// Here's the same method in a query:

var files =
	from file in new DirectoryInfo (Util.LINQPadFolder).GetFiles()
	select new
	{
		Name = Util.Highlight (file.Name, 
			file.Extension == ".exe" ? "yellow" :
			file.Extension == ".dll" ? "lightgreen" :
			null),  // null = no highlight			
		file.Length,
		file.LastWriteTime
	};
files.Dump();

// Util.WithStyle gives you even more control:

Util.WithStyle ("test", "font-size:30pt; font-weight:bold").Dump();

// Note that with Util.WithStyle, we set the (whole) CSS style attribute in one string.
// (With LINQPad's HTML controls, we set each property individually.)

// For more ways to customize Dump, see
// script://../../Customization_and_Extensibility/Customizing_results_-_colors_and_fonts

// For syntax highlighting, see script://../Cool_things_you_can_Dump/Syntax_highlighting