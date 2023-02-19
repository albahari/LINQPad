// LINQPad Statements

using System.Drawing

// Util.Chart uses the WinForms charting control under the covers. You can get at the underlying
// charting control by calling ToWinFormsChart(), and then make tweaks and customizations:

string[] xSeries = { "John", "Mary", "Sue" };
int[] ySeries = { 100, 120, 140 };

var winChart = xSeries.Chart().AddYSeries (ySeries, Util.SeriesType.Pie).ToWindowsChart();

// Make tweaks/customizations:

var area = winChart.ChartAreas.First();
area.Area3DStyle.Enable3D = true;
area.Area3DStyle.Inclination = 50;
winChart.Series.First().Points[2].SetCustomProperty ("Exploded", "true");
winChart.Dump();

// You can also ask for a bitmap and then dump or save it:

Bitmap bitmap = xSeries.Chart().AddYSeries (ySeries, Util.SeriesType.Pie).ToBitmap();
// Dump or save bitmap to a file...