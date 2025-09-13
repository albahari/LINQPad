// LINQPad Statements

// When you Dump a chart, it displays in its own tab after the script has finished executing.
// If you prefer to dump into the normal results window, call DumpInline() instead:

string[] xSeries = { "John", "Mary", "Sue" };
int[] ySeries = { 100, 120, 140 };

xSeries.Chart().AddYSeries (ySeries, Util.SeriesType.Pie).DumpInline ("Pie", 500, 500);

// You can optionally specify a heading and render size in pixels:
xSeries.Chart().AddYSeries (ySeries).DumpInline ("Sales", 500, 300);

// Calling DumpInline() is a shortcut for doing this:
xSeries.Chart().AddYSeries (ySeries).ToBitmap (500, 300).Dump ("Sales");