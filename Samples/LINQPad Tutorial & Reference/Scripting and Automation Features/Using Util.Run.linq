<Query Kind="Statements" />

// In that last example, we started an external process from LINQPad that executed another LINQPad script.
//
// If you want to run one LINQPad script from another, you can do it more efficiently with Util.Run:

string tempQueryPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempQueryPath, "Environment.MachineName.ToUpper()");
Util.Run (tempQueryPath, QueryResultFormat.Text).AsString().Dump();

// This is also covered in detail in https://www.linqpad.net/lprun.aspx