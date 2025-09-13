// LINQPad Statements

#LINQPad optimize-

using System.Threading.Tasks;

// LINQPad continually tracks the execution point in your script and displays it with indicators in the margin.

// Force debug mode on (in case you've enabled 'Optimize' in the Status Bar)

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

// Press Ctrl+Shift+J / Shift-Command-J to jump to the currently executing code.
// You can disable live execution tracking on the Script Menu (Auto Track Execution).

// TIP: If you have the Premium edition, hit 'Break' or click the margin to create a breakpoint.
// You can then single-step.