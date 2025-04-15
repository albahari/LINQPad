// LINQPad Statements

/* Results are formatted as HTML, so you can customize their appearance by customizing the CSS style sheet.

To do this globally, to to Edit | Preferences, Results and click the radio button for a custom style sheet.
You'll then be able to open the CSS editor and add your own customizations. For instance, to force LINQPad
to use a fixed-pitch font for all output, add the following:

body { font-family: Consolas }

You can do the same programmatically (for the current query) as follows: */

Util.HtmlHead.AddStyles ("body { font-family: Consolas }");
"This is fixed pitch".Dump();

//You can also specify styles just for specific elements that you dump:

Util.Highlight ("highlight").Dump();    // see also query://../All_about_Dump/More_tricks/Highlighting_data
Util.WithStyle ("This is light green", "background:lightgreen; font-family:Segoe UI").Dump();
Util.RawHtml ("<h1>Big</h1>").Dump();

// If you write styling methods in My Extensions, you'll be able to call them from anywhere.

// For more info on Util.Highlight, see query://../All_about_Dump/More_tricks/Highlighting_data
//                                  and query://../All_about_Dump/More_tricks/Advanced_Highlighting