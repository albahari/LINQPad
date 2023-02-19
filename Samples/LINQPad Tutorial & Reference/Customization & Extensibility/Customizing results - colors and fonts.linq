<Query Kind="Statements" />

/* Results are formatted as HTML, so you can customize their appearance by customizing the CSS style sheet.

To do this globally, to to Edit | Preferences, Results and click the radio button for a custom style sheet.
You'll then be able to open the CSS editor and add your own customizations. For instance, to force LINQPad
to use a fixed-pitch font for all output, add the following:

body, p, pre { font-family: Consolas }

You can do the same programmatically (for the current query) as follows: */

Util.HtmlHead.AddStyles ("body, p, pre { font-family: Consolas }");
"This is fixed pitch".Dump();

//You can also specify styles just for specific elements that you dump:

Util.Highlight ("highlight").Dump();
Util.WithStyle ("This is light green", "background:lightgreen; font-family:Segoe UI").Dump();
Util.RawHtml ("<h1>Big</h1>").Dump();

// If you can write methods to do this, and put them in My Extensions, you'll be able to call them from anywhere.