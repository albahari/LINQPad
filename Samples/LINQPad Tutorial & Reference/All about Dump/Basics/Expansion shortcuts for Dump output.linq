<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

/* When dumping complex objects, it can be useful to instantly expand/collapse to n levels.

On the toolbar just above the results, there's a 'Format' dropdown on the right. 
Try running this script, then press:
	Alt+1 - to collapse to 1 level     (Control-Command-1 on macOS)
	Alt+2 - to collapse to 2 levels    (Control-Command-2 on macOS)
	Alt+3 - to collapse to 3 levels    (Control-Command-3 on macOS)  */

CultureInfo.CurrentCulture.DateTimeFormat.Dump();

// You can set the initial collapse level with the collapseTo parameter:
// CultureInfo.CurrentCulture.DateTimeFormat.Dump (collapseTo:1);