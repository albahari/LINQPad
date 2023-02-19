<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

// Should you also want to define constructors, you can apply the [SetsRequiredMembers] attribute
// to inform the compiler that the constructor fully populates the required properties.

void Main()
{
	new Point (2, 3).Dump();              // OK - thanks to [SetsRequiredMembers]
	new Point { X = 2, Y = 3 }.Dump();    // OK
	//new Point().Dump();                 // Not OK
}

class Point
{
	public required int X { get; set; }
	public required int Y { get; set; }
	
	public Point()
	{		
	}
	
	[SetsRequiredMembers]
	public Point (int x, int y)
	{
		X = x;
		Y = y;
	}
}
