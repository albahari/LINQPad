// LINQPad Statements

// You can pass parameters to the main method and get a typed return value back as follows:

string tempScriptPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempScriptPath, @"<Query Kind=""Program"" />

int Main (int x, int y) => x * y;");  // Multiply two numbers together

using (var script = Util.Compile (tempScriptPath))
{
	script.Run (QueryResultFormat.Text, 10, 10).ReturnValue.Dump();
	script.Run (QueryResultFormat.Text, 11, 11).ReturnValue.Dump();
	script.Run (QueryResultFormat.Text, 12, 12).ReturnValue.Dump();
}

// You can also pass in and return complex objects, as long as the complex types are defined
// in a common assembly (or 'My Extensions') and are marked as [Serializable].