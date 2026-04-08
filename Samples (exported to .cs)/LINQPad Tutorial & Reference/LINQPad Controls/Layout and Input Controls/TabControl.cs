// LINQPad Statements

using LINQPad.Controls;
using System.Globalization;

// LINQPad also provides a simple TabControl.
// A TabControl is great when you have a lot of content to present.

var culture = CultureInfo.CurrentCulture;

var tc = new TabControl (
	("Calendar", new DumpContainer (culture.Calendar)),
	("TextInfo", new DumpContainer (culture.TextInfo)),
	("NumberFormat", new DumpContainer (culture.NumberFormat, options => options.CollapseTo = 1)),
	("Notes", new TextArea { Height = "100%", Width = "100%" })
)
.FillRemainingHeight()    // Call this if you want the TabControl fill the viewport height
.Dump();

// Calling FillRemainingHeight() makes the content pages scrollable, and allows children
// to use percentage-based height (as we did with "Notes" TextArea).

tc.SelectedIndexChanged += (sender, args) => tc.SelectedIndex.Dump ("New index");
