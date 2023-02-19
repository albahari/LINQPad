<Query Kind="Statements" />

var uncap = new Demo().Uncapsulate();

// Uncapsulate() returns a dynamic object. But unlike other dynamic objects, you can Dump() it directly:

uncap.Dump ("demo");          // Works without having to first cast
uncap._x.Dump ("demo.x");     // Works without having to first cast

// By default, you see both public and private members when you dump an uncapsulated object.
// Should you want to see just public members, call DumpPublic:

uncap.DumpPublic ("demo");

class Demo
{
	int _x = 1, _y = 2;
	
	public int X => _x;
	public int Y => _y;
}