<Query Kind="Statements" />

// All of the shortcuts are on the Debug menu. Press F11 repeatedly to step through this script:

for (int i = 0; i < 10; i++)
{
	int square = i * i;
	square.Dump();
}

// In the status bar, you'll see 'Debugger ATTACHED'. In the Locals window, you'll see the local
// variables ('i' and 'square'). In the Watch window, you can type an expression such as square * 2   
//
// TIP: At any point, hit F5 to resume