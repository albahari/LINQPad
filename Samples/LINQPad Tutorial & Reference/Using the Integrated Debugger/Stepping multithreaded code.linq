<Query Kind="Program" />

// LINQPad's debugger is designed for multithreaded code. Try running the following, then hit 'Break'.
// Then press F11 to step. Unlike in Visual Studio, execution continues until the *current thread* 
// encounters the next instruction. This makes it much easier to track what a thread is doing.
//
// (You can also step all threads using the 'Step All Threads' options on the Debug menu.)
//
// Click on the Threads debug window to see what each thread is doing. To switch to another thread,
// double-click the thread (or Ctrl+Click the thread icon in the editor margin).

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