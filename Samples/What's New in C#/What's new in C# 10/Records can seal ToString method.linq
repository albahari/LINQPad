<Query Kind="Statements" />

var point = new Point (3, 4);
point.ToString().Dump();
	
record Point (double X, double Y)
{
	// From C# 10, you can seal the ToString() method:
	public override sealed string ToString() => $"({X}, {Y})";
}