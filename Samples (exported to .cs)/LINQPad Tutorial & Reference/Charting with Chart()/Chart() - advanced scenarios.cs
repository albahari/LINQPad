// LINQPad Statements

using System.Drawing;

// For more flexibility, you can create an EChart directly.
// EChart is a LINQPad HTML control that wraps the Apache ECharts.js library.
// See script://../LINQPad_Controls/Media_and_Graphics/EChart_for_advanced_&_interactive_charting for a tutorial.

using LINQPad.Controls;    // EChart lives in LINQPad.Controls.

var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
var revenue = new[] { 120, 132, 101, 134, 190, 230 };
var expenses = new[] { 90, 100, 85, 95, 120, 140 };
var growth = revenue.Zip (expenses, (r, e) => e == 0 ? 0d : (r - e) * 100d / e).ToArray();

// For comparison, first create an EChart using the fluent .Chart() extension method:

var eChartAuto = months.Chart()
	.AddYSeries (revenue, Util.SeriesType.Column, "Revenue ($k)")
	.AddYSeries (expenses, Util.SeriesType.Column, "Expenses ($k)")
	.AddYSeries (growth, Util.SeriesType.Spline, "Growth %", useSecondaryYAxis: true)
	.ToEChart ("Monthly Revenue & Growth");

// Now create the identical EChart directly:

var eChartManual = new EChart (new
{
	title = new { text = "Monthly Revenue & Growth" },
	tooltip = new { trigger = "axis" },
	legend = new { },
	xAxis = new object[]
	{
		new { type = "category", data = months }
	},
	yAxis = new object[]
	{
		new { type = "value" },
		new { type = "value" }
	},
	series = new object[]
	{
		new { name = "Revenue ($k)",  type = "bar",  yAxisIndex = 0, data = revenue  },
		new { name = "Expenses ($k)", type = "bar",  yAxisIndex = 0, data = expenses },
		new { name = "Growth %",      type = "line", yAxisIndex = 1, data = growth, smooth = true }
	}
});

// Draw them side-by-side (they should look identical).
new FlexBox (eChartAuto, eChartManual).Dump();

// The manual approach lets you access all of ECharts options and chart types.