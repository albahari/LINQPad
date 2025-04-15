// LINQPad Statements

#r: "nuget: Microsoft.Office.Interop.Excel"
#r: "nuget: Microsoft.Office.Interop.Outlook"
#r: "nuget: Microsoft.Office.Interop.PowerPoint"
#r: "nuget: Microsoft.Office.Interop.Word"

using Excel = Microsoft.Office.Interop.Excel
using LINQPad.Spreadsheet
using Outlook = Microsoft.Office.Interop.Outlook
using PowerPoint = Microsoft.Office.Interop.PowerPoint
using Word = Microsoft.Office.Interop.Word

// After saving a file, you can interact with it using the COM API.
// (Press F4 and click "Add Office Interop" to reference the Office Interop libraries.)

var workbook = TimeZoneInfo.GetSystemTimeZones().ToSpreadsheet();
workbook.Save ("temp.xlsx");

var excel = new Excel.Application();
excel.Visible = true;
excel.Application.Workbooks.Open (Path.GetFullPath ("temp.xlsx"));
((Excel.Range)excel.Cells [2, 1]).Font.Color = System.Drawing.Color.Red;

// Obviously, this feature requires that Excel is installed and incurs the 
// performance overhead of an interprocess round-trip with each operation.
