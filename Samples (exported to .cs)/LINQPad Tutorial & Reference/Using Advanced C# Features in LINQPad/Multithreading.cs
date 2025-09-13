// LINQPad Statements

using System.Threading.Tasks;

// LINQPad is fine with multi-threaded code. Unlike with console apps, worker threads keep on running after
// the main thread has completed. If you want to stop everything, press Ctrl+Shift+F5 / Shift-Command-F5
// to kill the process.

for (int i = 0; i < 5; i++)
	new Thread (Foo) { Name = "Worker " + i }.Start();
	
for (int i = 0; i < 10; i++)
{
	"Hello from the main thread".Dump();
	Thread.Sleep(500);
}

void Foo()
{
	for (int i = 0; i < 10; i++)
	{
		(Thread.CurrentThread.Name + " -> " + i).Dump();
		Thread.Sleep (500);
	}
}

// If you have a Premium license, you'll notice the integrated debugger works fully supports multithreaded code!
// Just hit 'Break', set a breakpoint, or single-step (see Debug menu). You can single-step all threads at once
// or single-step while just tracking a single thread.