// LINQPad Statements

using System.Globalization;

// LINQPad normally applies a limit of 1000 rows when dumping (you can increase this in Settings > Results).
// To increase it for an individual Dump, do the following:
Enumerable.Range (0, 20000).Dump (new DumpOptions { MaxRows = 100000 });

// Alternatively:
DumpOptions.Default.MaxRows = 100000;
Enumerable.Range (0, 20000).Dump();

// Note that these limits do not apply when dumping to DataGrids
//  - see script://Rich_Text_vs_Data_Grids