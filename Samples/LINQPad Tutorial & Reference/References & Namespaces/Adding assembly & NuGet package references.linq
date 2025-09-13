<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

/* To reference a DLL or NuGet package, go to Script Properties (F4).

Or press Shift+Ctrl+P / Shift-Command-P to go directly to the NuGet package manager.

You can also add references by dragging and dropping files to the LINQPad editor.

You can reference:
	- Managed assemblies and native DLLs
	- NuGet packages (Developer/Premium edition - click 'Add NuGet' or Shift+Ctrl+P)
	- Other files such as text, JSON and XML files (these will get copied to the application base folder)
	- The ASP.NET Core Framework (press F4 and tick the checkbox)
	- The Windows SDK (press F4 and tick the checkbox)

After adding references, you can make this the default by clicking 'Set as default for new scripts'.

This script references the Json.NET NuGet package. Hence we can run the following code, which uses
the Json.NET package to parse a JSON string: */

string json = @"
{
	Customer:
	{ 
		""FirstName"": ""Joe"",
		""LastName"": ""Bloggs""
	}
}";

JsonConvert.DeserializeObject (json).Dump();

// Note: If you don't have a Developer/Premium edition of LINQPad, you can still restore NuGet
//       references in saved scripts such as this one.