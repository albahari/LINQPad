// LINQPad Statements

using LINQPad.Spreadsheet

// LINQPad provides a simple API to create a spreadsheet cell-by-cell:

var sheet = new Worksheet      // Worksheet is in the LINQPad.Spreadsheet namespace
{
	[1, 1] = "Revenue",
	[1, 2] = "Expenses",
	[1, 4] = "Profit",

	[2, 1] = 150230,
	[2, 2] = 25010,
	[2, 4] = new Cell { Formula = "B1-B2" },	
};

sheet.Open();   // or sheet.Save(...)

// This is much faster than using COM interop because no round-tripping takes place.
// LINQPad generates a fully populated .xlsx file when you call Open or Save.
// (Also, Excel doesn't need to be installed in order to generate an .xlsx file.)

// Tip: Use the ToCellName extension method to convert indexes to Excel column/row names:
(3, 5).ToCellName (zeroIndexed:false).Dump ("cell name");