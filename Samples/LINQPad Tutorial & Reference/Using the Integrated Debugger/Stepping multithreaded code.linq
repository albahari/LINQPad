<Query Kind="Program" />

// When you single-step in LINQPad, all threads resume (to avoid deadlocks).
// Execution then continues until the *current thread* reaches a new instruction.
// This makes it easy to track what the current thread is doing.
//
// LINQPad also provides 'Step All Threads' options on the Debug menu.
// These continue execution until *any thread* reaches a new instruction.
// Execution may stop sooner, jumping around between threads.
//
// Click on the Threads debug window to see what each thread is doing.
// To switch to another thread, double-click that thread
// (or Ctrl+Click the thread icon in the editor margin).

void Main()
{
	new Thread (Go) { Name = "Worker 1" }.Start();
	new Thread (Go) { Name = "Worker 2" }.Start();
	new Thread (Go) { Name = "Worker 3" }.Start();
	Go();
}

void Go()
{
	var random = new Random();
	for (int i = 0; i < 100000; i++)
	{
		switch (random.Next (3))
		{
			case 0: Foo1 (random.Next (100)); break;
			case 1: Foo2 (random.Next (150)); break;
			case 2: Foo3 (random.Next (200)); break;
		}
	}
}

void Foo1 (int delay) => Sleep (delay);
void Foo2 (int delay) => Sleep (delay);
void Foo3 (int delay) => Sleep (delay);

void Sleep (int delay) => Thread.Sleep (delay);