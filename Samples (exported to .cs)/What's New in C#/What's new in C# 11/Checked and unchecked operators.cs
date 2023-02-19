// LINQPad Statements

// C# 11 now lets you defined checked operators by adding the checked keyword.
// When you do so, you must also define a matching unchecked operator (note that 'unchecked' is implicit).

var p1 = new Point (int.MaxValue, int.MaxValue);
(p1 + new Point (1, 1)).Dump();  // Succeeds (unchecked)

checked
{
	(p1 + new Point (1, 1)).Dump();  // Fails (checked)	
}

record Point (int X, int Y)
{
	// You can see how this compiles by clicking the 'IL+Native' tab.
	public static Point operator checked + (Point left, Point right) =>
		new Point (checked (left.X + right.X), checked (left.Y + right.Y));

	public static Point operator /*(unchecked)*/ + (Point left, Point right) =>
		new Point (left.X + right.X, left.Y + right.Y);
}

// Checked operators are required to properly implement generic Math.
//
// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/checked-user-defined-operators.md
