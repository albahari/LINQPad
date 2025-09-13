// LINQPad Program

using System.Threading.Tasks;

// LINQPad works just fine with unsafe code.
// In 'C# Program' mode, remember to add the 'unsafe' modifier to the Main method.

unsafe void Main()
{
	sizeof (Point).Dump();
}

struct Point
{
	public int X, Y;
}
