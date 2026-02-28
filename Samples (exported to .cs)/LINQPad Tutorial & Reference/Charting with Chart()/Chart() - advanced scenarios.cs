// LINQPad Statements

using System.Drawing;

// For more elaborate scenarios, create an EChart directly (this wraps the Apache ECharts.js library).
// See script://../LINQPad_Controls/EChart_for_advanced_&_interactive_charting for a tutorial.

using LINQPad.Controls;    // EChart lives in LINQPad.Controls.

// The easiest way to build this is to press Ctrl+I / Command-I and ask AI - it knows how to create every kind of EChart!
var eChart = new EChart (new
{
	title = new { text = "Monthly Revenue & Growth", subtext = "2025 Fiscal HY", left = "center" },
	tooltip = new { trigger = "axis", axisPointer = new { type = "cross" } },
	legend = new { data = new[] { "Revenue", "Expenses", "Growth" }, top = "12%" },
	xAxis = new { type = "category", data = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" } },
	yAxis = new object[]
	{
		new { type = "value", name = "Amount", axisLabel = new { formatter = "${value}K" } },
		new { type = "value", name = "Growth", axisLabel = new { formatter = "{value}%" } }
	},
	series = new object[]
	{
		new { name = "Revenue", type = "bar", data = new[] { 120, 132, 101, 134, 190, 230 } },
		new { name = "Expenses", type = "bar", data = new[] { 90, 100, 85, 95, 120, 140 } },
		new { name = "Growth %", type = "line", yAxisIndex = 1, smooth = true, data = new[] { 5, 10, -3, 8, 22, 18 }, areaStyle = new { opacity = 0.15 } }
	},
	dataZoom = new[] { new { type = "inside" }, new { type = "slider" } }
});

eChart.Dump();
