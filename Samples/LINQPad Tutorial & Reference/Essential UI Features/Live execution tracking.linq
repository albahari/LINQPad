<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// LINQPad continually tracks the execution point in your query and displays it with indicators in the margin.

#LINQPad optimize-       // Force debug mode on (just in case you've enabled 'release mode' in Preferences)

while (true)
{
	Hello();
	World();
}

void Hello()
{
	Console.Write ("Hello, ");
	Thread.Sleep (1000);
}

void World()
{
	Console.WriteLine ("World");
	Thread.Sleep (1000);
}

// Press Ctrl+Shift+J to jump to the currently executing code.
// You can disable live execution tracking on the Query Menu (Auto Track Execution).

// TIP: If you have the Premium edition, hit 'Break' or click the margin to create a breakpoint.
// You can then single-step.