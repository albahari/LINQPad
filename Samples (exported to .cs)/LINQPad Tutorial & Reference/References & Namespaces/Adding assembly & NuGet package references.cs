// LINQPad Statements

#r "nuget: System.Reactive"

using System.Reactive.Linq;

/* To reference a DLL or NuGet package, go to Script Properties (F4).

Or press Shift+Ctrl+P / Shift-Command-P to go directly to the NuGet Package Manager.

You can also add references by dragging and dropping files to the LINQPad editor.

You can reference:
	- Managed assemblies and native DLLs
	- NuGet packages (Developer/Premium edition - click 'Add NuGet' or Shift+Ctrl+P)
	- Other files such as text, JSON and XML files (these will get copied to the application base folder)
	- The ASP.NET Core Framework (press F4 and tick the checkbox)
	- The Windows SDK (press F4 and tick the checkbox)

After adding references, you can make this the default by clicking 'Set as default for new scripts'.

This script references the System.Reactive NuGet package. Hence we can run the following code: */

Observable.Interval (TimeSpan.FromSeconds (0.5)).Take(10).Dump();

/* To add references programmatically, use the #:package or #r directive
  (these must appear at the top of the script):

#:package System.Reactive@6.*    // Reference NuGet Package System.Reactive version 6.(highest)
#r "nuget:System.Reactive"       // Reference NuGet Package System.Reactive
#r "c:\temp\MyAssembly.dll"      // Reference a DLL
#r "..\..\MyAssembly.dll"        // Reference a DLL (relative path)

You can reference a C# project (.csproj) via the #:project directive:

#:project ../ClassLib/ClassLib.csproj

*/