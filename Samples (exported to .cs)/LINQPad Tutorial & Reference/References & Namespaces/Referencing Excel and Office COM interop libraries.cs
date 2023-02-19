// LINQPad Statements

#r: "nuget: Microsoft.Office.Interop.Excel"
#r: "nuget: Microsoft.Office.Interop.Outlook"
#r: "nuget: Microsoft.Office.Interop.PowerPoint"
#r: "nuget: Microsoft.Office.Interop.Word"

using Excel = Microsoft.Office.Interop.Excel
using Outlook = Microsoft.Office.Interop.Outlook
using PowerPoint = Microsoft.Office.Interop.PowerPoint
using Word = Microsoft.Office.Interop.Word

// You can reference Office and other COM libraries by adding a NuGet reference.
//
// There's a special shortcut for adding the Office interop libraries and namespaces:
//    Press F4 and click 'Add Office Interop'.

// Excel interop:

var excel = new Excel.Application();
excel.Visible = true;
Excel.Workbook workBook = excel.Workbooks.Add();
((Excel.Range)excel.Cells [1, 1]).Font.FontStyle = "Bold";
((Excel.Range)excel.Cells [1, 1]).Value2 = "Hello World";
workBook.SaveAs (Path.GetTempFileName() + ".xlsx");

// Word interop:

var wordApp = new Word.Application();
wordApp.Visible = true;
Word.Document doc = wordApp.Documents.Add();
wordApp.Selection.Text = "Hello";
wordApp.Activate();

// MSDN info on Office interop:
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interop/how-to-access-office-onterop-objects