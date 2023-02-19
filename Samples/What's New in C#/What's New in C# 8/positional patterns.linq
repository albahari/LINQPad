<Query Kind="Program" />

// The positional pattern uses deconstruction in matching:

void Main()
{
	GetQuadrant (new Point (-1, 1)).Dump();
}

static Quadrant GetQuadrant (Point point) => point switch
{
	(0, 0) => Quadrant.Origin,
	var (x, y) when x > 0 && y > 0 => Quadrant.One,
	var (x, y) when x < 0 && y > 0 => Quadrant.Two,
	var (x, y) when x < 0 && y < 0 => Quadrant.Three,
	var (x, y) when x > 0 && y < 0 => Quadrant.Four,
	var (_, _) => Quadrant.OnBorder,
	_ => Quadrant.Unknown
};

public class Point
{
	public int X { get; }
	public int Y { get; }

	public Point (int x, int y) => (X, Y) = (x, y);

	public void Deconstruct (out int x, out int y) =>
		(x, y) = (X, Y);
}

public enum Quadrant
{
	Unknown,
	Origin,
	One,
	Two,
	Three,
	Four,
	OnBorder
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#positional-patterns