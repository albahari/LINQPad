// LINQPad Statements

// If you plan to run the same script more than once, you can speed things up with Util.Compile.

string tempQueryPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempQueryPath, "Environment.MachineName.ToUpper()");

using (var query = Util.Compile (tempQueryPath))
{
	// The same process will be re-used for all three executions: 
	query.Run (QueryResultFormat.Text).AsString().Dump();
	query.Run (QueryResultFormat.Text).AsString().Dump();
	query.Run (QueryResultFormat.Text).AsString().Dump();
}

// You can call Util.Run and Util.Compile from Visual Studio projects, too. Just add a reference to LINQPad.Runtime.dll
// (or add a reference to the LINQPad.Runtime NuGet package).