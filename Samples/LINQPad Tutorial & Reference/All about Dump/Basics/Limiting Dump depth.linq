<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

// By default, LINQPad limits the recursion depth to 5 levels, when dumping.
// You can change this as follows:

CultureInfo.CurrentCulture.DateTimeFormat.Dump (1);   // One level
CultureInfo.CurrentCulture.DateTimeFormat.Dump (2);   // Two levels

// This feature is very useful with large object graphs that could take a long time to walk.

// Notice that unrendered objects appear as clickable hyperlinks.