<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.DataVisualization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Windows.Forms.DataVisualization.Charting</Namespace>
</Query>

// If you dump a WPF or Windows Forms control, LINQPad will render it. This creates another way
// to visualize data.

void Main()
{
	new[] { ("Food", 10.3), ("Textiles", 8.1), ("Electronics", 15.7) }.DumpPie();
}

public static class MyExtensions
{
	// Move this method into the 'My Extensions' query to make it available to all queries.
	// Notice that we've added a reference to System.Windows.Forms.DataVisualization (press F4).
	
	public static void DumpPie (this IEnumerable<(string, double)> values, string title = null)
	{
		Series series = new Series { ChartType = SeriesChartType.Pie };
		series.CustomProperties = "PieDrawingStyle=Concave";

		foreach (var value in values)
			series.Points.AddXY (value.Item1, value.Item2);

		Chart chart = new Chart();
		chart.Series.Add (series);
		chart.ChartAreas.Add (new ChartArea());
		chart.Dump (title);
	}
}

// Custom visualizers are covered in detail in https://www.linqpad.net/CustomVisualizers.aspx
