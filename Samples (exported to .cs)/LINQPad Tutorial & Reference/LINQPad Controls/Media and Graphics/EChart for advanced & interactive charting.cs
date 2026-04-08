// LINQPad Statements

using LINQPad.Controls;

// LINQPad's EChart control lets you create advanced interactive charts using the Apache ECharts library.
// EChart is essentially a thin wrapper over ECharts that handles the JavaScript plumbing.
//
// EChart is very flexible, but for simple non-interactive charting scenarios,
// Util.Chart is an easier option - see script://../../Charting_with_Chart()

// BASIC LINE CHART

var lineChart = new EChart (new
{
	// For ECharts documentation, see: https://echarts.apache.org/examples/
	// Or press Ctrl+I / Command-I and ask AI - it knows how to create every kind of EChart
	title = new { text = "Simple Line Chart" },
	tooltip = new { trigger = "axis" },
	xAxis = new { type = "category", data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri" } },
	yAxis = new { type = "value" },
	series = new object[]
	{
		new { name = "Series A", type = "line", data = GetRandomNumbers(5) },
		new { name = "Series B", type = "line", data = GetRandomNumbers(5) }
	}
});

lineChart.Dump();

// By default, LINQPad enables a toolbar, legend, tooltips, narrow side margins and SVG rendering, and disables animations.
// You can eliminate these defaults by setting the DefaultOptionsJson property to null or "{}".

// INTERACTIVE/DYNAMIC CHART (responding to events and updating data)

var dc = new DumpContainer (Util.Highlight ("Click a slice to see details\n\nDouble-click to randomize"));

var interactiveChart = new EChart (
	new
	{
		title = new { text = "Interactive Pie Chart" },
		// NB: With pie charts, **remove the legend**, otherwise legend and pie may overlap without special positioning.
		legend = new { show = false },  // Necessary for pie charts
		series = new[] { new { type = "pie", radius = "65%", data = GetNameValueData() } }
	},
	// You can optionally override width/height. The default is 100% width and 95vh height.
	width: "600px", height: "400px"
);

// EChart exposes events for ChartClick, ChartDoubleClick, ChartMouseOver, ChartMouseOut, ChartGlobalOut, ChartLegendSelectChanged, and ChartDataZoom
interactiveChart.ChartClick += (sender, e) => dc.Content = new { e.Name, e.Value, e.SeriesName, e.DataIndex };

// We'll update the chart dynamically when the user double-clicks on a bar:
interactiveChart.ChartDoubleClick += (sender, e) => interactiveChart.Update (new
{
	series = new[] { new { type = "pie", radius = "65%", data = GetNameValueData() } }
});

new FlexBox (interactiveChart, dc) { Align = "center" }.Dump ();

// RAW JSON
// You can also pass in raw JSON strings. This is useful if the chart's structure is dynamic.

var json = """
	{
		"series": [ { "type": "gauge", "data": [{ "value": 95, "name": "km/h" }] } ]
	}
	""";

var jsonChart = new EChart (chartJson: json);
jsonChart.Dump ("Guage");

// You can extract the SVG for any chart (after it's dumped) as follows:
Util.OnDemand ("Show SVG for lineChart", () => lineChart.GetSvgAsync ()).Dump ();

int[] GetRandomNumbers (int count) => Enumerable.Range (0, count).Select (x => Random.Shared.Next (30)).ToArray();

object[] GetNameValueData() => new[] { "A", "B", "C", "D", "E" }
	.Select (l => (object)new { name = l, value = Random.Shared.Next (10, 50) }).ToArray();

// For the full ECharts documentation, see: https://echarts.apache.org/examples/
