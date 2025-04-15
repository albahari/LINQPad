// LINQPad Statements

using LINQPad.Spreadsheet

// LINQPad's API also supports multi-sheet documents:

var sheet1 = new Worksheet      // Worksheet is in the LINQPad.Spreadsheet namespace
{
	[1, 1] = "Some string data",
	[1, 2] = DateTime.Now,
	[1, 3] = 123.456m,
	[1, 4] = true,

	Name = "Data type demo",
};

var sheet2 = new Worksheet
{
	[1, 1] = "First Name",
	[2, 1] = "Last Name",
	[3, 1] = "Date of birth",
	
	Name = "Customers",
	Options = new WorksheetOptions { FreezeTopRow = true, GenerateTable = true }
};

for (int i = 1; i < 51; i++)
{
	sheet2 [1, i+1] = "Jane" + i;
	sheet2 [2, i+1] = "Doe" + i;
	sheet2 [3, i+1] = new DateTime (2000, 1, 1).AddMonths (-1);
}

new Workbook (sheet1, sheet2).Open();

// or: new Workbook (sheet1).AddSheet (sheet2).Open();