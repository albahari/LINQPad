<Query Kind="Program" />

void Main()
{
	"Main".Dump();
}

// Another way to control execution is by defining methods called Main1(), Main2()... to Main9().
// These act as alternative entry points which you can invoke with a hotkey:

void Main1() => "You ran Main1()".Dump();   // Press Alt+Shift+1 to run Main1()   (Control-Option-1 on macOS)
void Main2() => "You ran Main2()".Dump();   // Press Alt+Shift+2 to run Main2()   (Control-Option-2 on macOS)
void Main3() => "You ran Main3()".Dump();   // Press Alt+Shift+3 to run Main3()   (Control-Option-3 on macOS)
// ... and so on to Main9

// Note that this only works in 'C# Program' mode.