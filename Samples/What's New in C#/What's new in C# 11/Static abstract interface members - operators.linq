<Query Kind="Program" />

// Interfaces in C# 11 can also include operators:

interface IAddable<TSelf> where TSelf : IAddable<TSelf>
{
	static abstract TSelf operator + (TSelf left, TSelf right);
}

// Example implementation:

record Point (int X, int Y) : IAddable<Point>
{
	public static Point operator + (Point left, Point right) =>
		new Point (left.X + right.X, left.Y + right.Y);
}

// You can call operator polymorphically via a constrained type parameter:

T AddAny<T> (T value1, T value2) where T : IAddable<T> => value1 + value2;

// Demo:

void Main()
{
	var point1 = new Point (1, 1);
	var point2 = new Point (2, 2);
	
	// Call the addition operator directly:
	(point1 + point2).Dump();
	
	// Call the polymorphic AddAny method:
	AddAny (point1, point2).Dump();
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/static-abstracts-in-interfaces.md

