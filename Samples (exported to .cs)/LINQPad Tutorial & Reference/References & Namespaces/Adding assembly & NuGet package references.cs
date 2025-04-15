// LINQPad Statements

#r: "nuget: Newtonsoft.Json"

using Newtonsoft.Json

/* To reference a DLL or NuGet package, go to Query Properties (F4).

Or press Shift+Ctrl+P to go directly to the NuGet package manager.

You can also add references by dragging and dropping files to the LINQPad editor.

You can reference:
	- Managed assemblies and native DLLs
	- NuGet packages (Developer/Premium edition - click 'Add NuGet' or Shift+Ctrl+P)
	- Other files such as text, JSON and XML files (these will get copied to the application base folder)
	- The ASP.NET Core Framework (press F4 and tick the checkbox)
	- The Windows SDK (press F4 and tick the checkbox)

After adding references, you can make this the default by clicking 'Set as default for new queries'.

This query references the Json.NET NuGet package. Hence we can run the following code, which uses
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
//       references in saved queries such as this o ne.