// LINQPad Statements

using LINQPad.Controls;
using System.Globalization;

// LINQPad also provides a simple TabControl.
// A TabControl is great when you have a lot of content to present.

var culture = CultureInfo.CurrentCulture;

var tc = new TabControl (
	("Calendar", new DumpContainer (culture.Calendar)),
	("TextInfo", new DumpContainer (culture.TextInfo)),
	("NumberFormat", new DumpContainer (culture.NumberFormat, options => options.CollapseTo = 1)),
	("Notes", new TextArea())
).Dump();

tc.SelectedIndexChanged += (sender, args) => tc.SelectedIndex.Dump ("New index");


// Here's an elaborate example, with a DumpContainer, FlexBox and a refreshable chart:

DumpContainer dcSortItems, dcLog;
Button btnSort;
var numbers = Enumerable.Range (0, 20).Select (r => Random.Shared.Next(100)).ToList();
var eChart = GetLINQPadChart().ToEChart (height: "350px");

var tcQuickSort = new TabControl (
	("Overview", new MarkdownViewer ("**Quicksort** is a popular fast sorting algorithm, developed by Tony Hoare in 1959.\n\n...")),
	("Demo",
		new FlexBox ("column", "1em",
			btnSort = new Button ("Sort"),
			new FlexBox (
				dcSortItems = new DumpContainer (numbers) { Style = "max-height: 350px; overflow: auto" },
				eChart
			)
		)
	),
	("Log", dcLog = new DumpContainer())
);

btnSort.Click += (sender, args) =>
{
	var sw = Stopwatch.StartNew();
	numbers.Sort();
	sw.Stop();
	dcSortItems.Refresh();
	eChart.Update (GetLINQPadChart());
	dcLog.AppendContent ($"Sorted {numbers.Count} items in {sw.ElapsedTicks} ticks");
};

tcQuickSort.SizeAllTabsToTallest = true;  // Prevent layout shifts: useful when there's stuff above the TabControl
tcQuickSort.Dump ("Quicksort");

LINQPadChart GetLINQPadChart() => Enumerable.Range (0, numbers.Count)
	.Chart()
	.AddYSeries (x => numbers[x], Util.SeriesType.Point);