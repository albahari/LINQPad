<Query Kind="Statements" />

// You can invoke an external debugger such as Visual Studio by calling Debugger.Launch() / Debugger.Break()
//
// This is handy if you want to debug other assemblies. Note that you must ensure LINQPad's debugger is not
// also attached. You can do this by clearing all breakpoints and unchecking the blue/red 'break on exception'
// toolbar buttons above, OR by running the query with Ctrl+F5.

Debugger.Launch();

for (int i = 0; i < 10; i++)
{
	if (i == 5) Debugger.Break();
	i.Dump();
}
