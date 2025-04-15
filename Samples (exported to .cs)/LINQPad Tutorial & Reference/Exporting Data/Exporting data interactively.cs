// LINQPad Statements

/* You can interactively export data in any of the following ways:

	- Click the ellipses on a table in the results view  (Excel)
	- Click the "Export" menu on the results toolbar     (Excel, HTML, Word)
	- Right-click a data grid (in Data Grid mode)        (Excel)
	
	You can try each option with the following query:
*/

bool enableDataGrids = false;   // You can alse the toolbar button to enable grids

var sampleCollection = TimeZoneInfo.GetSystemTimeZones();
sampleCollection.Dump (enableDataGrids);

// The "Export to Excel via .xlsx" option creates a multi-sheet workbook when multiple
// result sets have been dumped.