<Query Kind="Statements" />

// Each DumpContainer has its own DumpOptions property that you can use to override
// such things as formatting strings, dump depth (MaxDepth), column exclusions, etc.
var dc = new DumpContainer (new { X = 1, Y = 2, Z = 3, Time = DateTime.Now });
dc.DumpOptions.MembersToExclude = "X,Y";
dc.DumpOptions.FormatStrings.DateTime = "yyyy-MM-dd";
dc.Dump();

// You can also apply CSS styles dynmically by setting the Style property (like Util.WithStyle).
dc.Style = "color:red; font-weight:bold";

// (Note that when setting the Style we set the (whole) CSS style attribute in one string
//  With LINQPad's HTML controls, we set each property individually.)
