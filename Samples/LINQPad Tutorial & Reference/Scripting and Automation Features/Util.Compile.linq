<Query Kind="Statements" />

// If you plan to run the same script more than once, you can speed things up with Util.Compile.

string tempScriptPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempScriptPath, "Environment.MachineName.ToUpper()");

using (var script = Util.Compile (tempScriptPath))
{
	// The same process will be re-used for all three executions: 
	script.Run (ResultFormat.Text).AsString().Dump();
	script.Run (ResultFormat.Text).AsString().Dump();
	script.Run (ResultFormat.Text).AsString().Dump();
}

// You can call Util.Run and Util.Compile from Visual Studio projects, too. Just add a reference to LINQPad.Runtime.dll
// (or add a reference to the LINQPad.Runtime NuGet package).