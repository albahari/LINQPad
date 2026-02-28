<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// To create an updateable chart, first convert the chart to an HTML EChart and Dump it:
var eChart = GetSinWaveChart (0).ToEChart ("Rolling Sine").Dump();

// Then to perform an update, call the EChart's Update method as follows:
for (int i = 0; i < 360; i++)
{
	eChart.Update (GetSinWaveChart (i));  // does an efficient react-style DOM update
	await Task.Delay (50);
}

LINQPadChart GetSinWaveChart (double degreesOffset) =>
	Enumerable.Range (0, 360)
		.Select (d => d + degreesOffset)
		.Chart (d => d, d => Math.Sin (d * Math.PI / 180), Util.SeriesType.Line);
