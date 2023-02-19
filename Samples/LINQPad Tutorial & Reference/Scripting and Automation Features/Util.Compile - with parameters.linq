<Query Kind="Statements" />

// You can pass parameters to the main method and get a typed return value back as follows:

string tempQueryPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempQueryPath, @"<Query Kind=""Program"" />

int Main (int x, int y) => x * y;");  // Multiply two numbers together

using (var query = Util.Compile (tempQueryPath))
{
	query.Run (QueryResultFormat.Text, 10, 10).ReturnValue.Dump();
	query.Run (QueryResultFormat.Text, 11, 11).ReturnValue.Dump();
	query.Run (QueryResultFormat.Text, 12, 12).ReturnValue.Dump();
}

// You can also pass in and return complex objects, as long as the complex types are defined
// in a common assembly (or 'My Extensions') and are marked as [Serializable].