<Query Kind="Statements">
  <NuGetReference>Microsoft.Office.Interop.Excel</NuGetReference>
  <NuGetReference>Microsoft.Office.Interop.Outlook</NuGetReference>
  <NuGetReference>Microsoft.Office.Interop.PowerPoint</NuGetReference>
  <NuGetReference>Microsoft.Office.Interop.Word</NuGetReference>
  <Namespace>Excel = Microsoft.Office.Interop.Excel</Namespace>
  <Namespace>LINQPad.Spreadsheet</Namespace>
  <Namespace>Outlook = Microsoft.Office.Interop.Outlook</Namespace>
  <Namespace>PowerPoint = Microsoft.Office.Interop.PowerPoint</Namespace>
  <Namespace>Word = Microsoft.Office.Interop.Word</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

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
