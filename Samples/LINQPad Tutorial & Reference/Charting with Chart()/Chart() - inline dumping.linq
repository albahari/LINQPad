<Query Kind="Statements" />

// When you Dump a chart under Windows, it displays in its own tab after the script has finished executing.
// If you prefer to dump into the normal results window, call DumpInline() instead:

string[] xSeries = { "John", "Mary", "Sue" };
int[] ySeries = { 100, 120, 140 };
var chart = xSeries.Chart().AddYSeries (ySeries, Util.SeriesType.Pie);

chart.DumpInline ("Pie", 500, 500);

// You can optionally specify a heading and render size in pixels:
chart.DumpInline ("Sales", 500, 300);

// Calling DumpInline() is a shortcut for converting the chart into an HTML EChart and dumping it:
chart.ToEChart ("Sales", "500px", "300px").Dump();

// .ToEChart returns a LINQPad.Controls.EChart, so you can include it with other controls.
// This is great if you want to keep everything on the same page.
new LINQPad.Controls.FlexBox (chart.ToEChart(), new LINQPad.Controls.Button("button")).Dump();

// For more info on EChart, see script://../LINQPad_Controls/EChart_for_advanced_&_interactive_charting

// Note: on macOS, charts always display inline using EChart, so Dump is the same as DumpInline.