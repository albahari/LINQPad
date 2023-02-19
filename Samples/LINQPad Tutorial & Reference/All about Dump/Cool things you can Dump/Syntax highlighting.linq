<Query Kind="Statements" />

// LINQPad can add syntax-highlighting to strings in any of the following languages before dumping:
//   - XML, JSON, CSharp, VB, FSharp, SQL, HTML, JavaScript, PowerShell, Python
//
// Just call Util.SyntaxColorText and dump the result:

string json   = @"{ ""Name"":""Alice"", ""Age"": 32}";
string csharp = "class Program\r\n{\r\npublic string Message = \"Hello\";\r\n}";
string sql    = "select * from customers\r\nGO";

Util.SyntaxColorText (json,   SyntaxLanguageStyle.Json)  .Dump ("JSON"); 
Util.SyntaxColorText (csharp, SyntaxLanguageStyle.CSharp).Dump ("C#"); 
Util.SyntaxColorText (sql,    SyntaxLanguageStyle.SQL)   .Dump ("SQL");

// LINQPad can also apply autoformatting to XML, JSON, CSharp and VB:

Util.SyntaxColorText (json,   SyntaxLanguageStyle.Json,   autoFormat:true).Dump ("JSON - formatted");
Util.SyntaxColorText (csharp, SyntaxLanguageStyle.CSharp, autoFormat:true).Dump ("C# - formatted");

// You can access the syntax-colored text as HTML via the Html property:
string html = Util.SyntaxColorText (json, SyntaxLanguageStyle.Json, autoFormat:true).Html;
Util.SyntaxColorText (html, SyntaxLanguageStyle.HTML).Dump ("HTML");

// To display syntax-highlighted text in a separate panel with outlining, call DumpToNewPanel()
// Util.SyntaxColorText (csharp, SyntaxLanguageStyle.CSharp, autoFormat:true).DumpToNewPanel(); 