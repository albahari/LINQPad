<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
</Query>

// On Windows, Util.Chart uses the WinForms charting control under the covers.
// You can get at the underlying  charting control by calling ToWinFormsChart()
// and then make tweaks and customizations:

string[] xSeries = { "John", "Mary", "Sue" };
int[] ySeries = { 100, 120, 140 };

var chart = xSeries.Chart().AddYSeries (ySeries, Util.SeriesType.Pie);

#if WINDOWS
	var winChart = chart.ToWindowsChart();
	
	// Make tweaks/customizations:
	
	var area = winChart.ChartAreas.First();
	area.Area3DStyle.Enable3D = true;
	area.Area3DStyle.Inclination = 50;
	winChart.Series.First().Points[2].SetCustomProperty ("Exploded", "true");
	winChart.Dump();
#else
	// On macOS, use EChart for more functionality:
	// script://../LINQPad_Controls/EChart_for_advanced_&_interactive_charting
#endif
