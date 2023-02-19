<Query Kind="Program" />

// C# 11 lets you define static abstract members in interfaces:

interface IParseable<TSelf> where TSelf : IParseable<TSelf>
{
	static abstract TSelf Parse (string s);
}

// Example implementation:

record Point (int X, int Y) : IParseable<Point>
{
	public static Point Parse (string s)
	{
		var match = Regex.Match (s, @"Point { X = (\d+), Y = (\d+) }");
		if (!match.Success) throw new ArgumentException ("Cannot parse point - invalid string");
		return new Point (int.Parse (match.Groups [1].Value), int.Parse (match.Groups [2].Value));
	}
}

// You can call static interface methods polymorphically via a constrained type parameter:

T ParseAny<T> (string s) where T : IParseable<T> => T.Parse (s);

// Demo:

void Main()
{
	string pointString = new Point (2, 3).ToString().Dump ("Point string");
	
	// Call the Parse method directly:
	Point.Parse (pointString).Dump();
	
	// Call the polymorphic ParseAny method:
	ParseAny<Point> (pointString).Dump();
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/static-abstracts-in-interfaces.md