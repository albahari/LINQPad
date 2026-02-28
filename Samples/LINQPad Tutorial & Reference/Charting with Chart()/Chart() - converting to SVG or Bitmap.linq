<Query Kind="Statements" />

// After calling .ToEChart on a chart and dumping it, you can extract the SVG:

string[] xSeries = { "John", "Mary", "Sue" };
int[] ySeries = { 100, 120, 140 };
var chart = xSeries.Chart().AddYSeries (ySeries, Util.SeriesType.Pie);

var eChart = chart.ToEChart ("Sales", "500px", "300px").Dump();

eChart.GetSvgAsync().Dump ("svg");

// On Windows, you can also get a Bitmap:
#if WINDOWS
	System.Drawing.Bitmap bitmap = chart.ToBitmap (500, 300);
	// Save or dump the bitmap:
	bitmap.Dump();
#endif