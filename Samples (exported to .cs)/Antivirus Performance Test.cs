// LINQPad Program

#r: "nuget: Microsoft.CodeAnalysis.CSharp"

using Microsoft.CodeAnalysis
using Microsoft.CodeAnalysis.CSharp
using Microsoft.CodeAnalysis.CSharp.Syntax
using Microsoft.CodeAnalysis.Text
using Microsoft.CodeAnalysis.Emit
using System.Runtime.InteropServices
using System.Runtime.Loader

// Antivirus Performance Test
//
// This query generates a tiny (2KB) DLL and times how long it takes to load.
//
// Normal results on a healthy computer:
//    Windows:
//       - under 30 milliseconds with Microsoft Defender active & scanning
//       - under 1 millisecond without antivirus software scanning
//    MacOS:
//       - under 0.3 milliseconds
//
// If it takes over 100ms, consider adding antivirus exclusions for these process names:
//  - LINQPad8.exe (LINQPad8 on MacOS)
//  - LINQPad8-x64.exe
//  - devenv.exe (if you use Visual Studio)
//
// Alternatively, on Windows 11, enable Dev Drive: https://learn.microsoft.com/en-us/windows/dev-drive/
// LINQPad automatically detects Windows Dev Drive and uses it as a compilation target if available.
//
// If you still get figures above 100ms on Windows, it may be due to an OS bug whereby the filter
// for synchronous online scanning fails open. When this occurs, you will experience a dramatic
// performance increase by turning off "Smart App Control" and/or "Cloud-delivered protection".

void Main()
{
	new
	{
		LINQPadProcessName = Path.GetFileName (Environment.ProcessPath),
		WindowsDevDrive = Util.DevDriveRoot ?? "(not set up)",
		OutputFolder = Environment.CurrentDirectory
	}.Dump();
	
	for (int i = 1; i < 11; i++)
	{
		string path = $"test{i}.dll";
		CreateTinyAssembly (path);

		var sw = Stopwatch.StartNew();
		Assembly.LoadFile (Path.GetFullPath (path));    // This should not take long!
		sw.Stop();

		$"Test {i} - {Math.Round (sw.Elapsed.TotalMilliseconds, 3)} milliseconds".Dump();
	}
	Environment.Exit (0);   // End the process right away to release locks on the assemblies.
}

void CreateTinyAssembly (string path)
{
	// Use the Microsoft Roslyn API to compile a DLL from a really simple class.
	// Start with a SyntaxTree containing the source code:
	var tree = CSharpSyntaxTree.ParseText ($"class Test{_random.Next()} {{}}");
	
	var compilation = CSharpCompilation    // Create a compilation
		.Create ("test")
		.WithOptions (new CSharpCompilationOptions (OutputKind.DynamicallyLinkedLibrary))
		.AddSyntaxTrees (tree)
		.AddReferences (MetadataReference.CreateFromFile (typeof (int).Assembly.Location));
	
	EmitResult result = compilation.Emit (path);   // Compile to disk
	if (!result.Success)
	{
		result.Diagnostics.Dump ();
		throw new Exception ("Could not compile code");
	}
}

static Random _random = new();