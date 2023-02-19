<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Numerics</Namespace>
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

// NB: This demo requires .NET 7+   https://dotnet.microsoft.com/en-us/download/dotnet/7.0
//
// .NET 7 includes the IAdditionOperators interface, which is defined as follows:
//
// public interface IAdditionOperators<TSelf, TOther, TResult>
//    where TSelf : IAdditionOperators<TSelf, TOther, TResult>
// {
//   static abstract TResult operator + (TSelf left, TOther right);
//   static abstract TResult operator checked + (TSelf left, TOther right);
// }
//
// Let's implement this interface:

record Point (int X, int Y) : IAdditionOperators<Point, Point, Point>
{
	public static Point operator + (Point left, Point right) =>
		new Point (left.X + right.X, left.Y + right.Y);

	public static Point operator checked + (Point left, Point right) =>
		new Point (checked(left.X + right.X), checked(left.Y + right.Y));
}

// As in the preceding example, you can call the operator polymorphically via a constrained type parameter.
// This time, we'll demo it by writing an extension method that sums a sequence of values:

static class Extensions
{
	public static T SumEx<T> (this IEnumerable<T> source) where T : IAdditionOperators<T, T, T>
	{
		using var rator = source.GetEnumerator();
		if (!rator.MoveNext()) throw new InvalidOperationException ("Empty sequence");

		T total = rator.Current;

		while (rator.MoveNext())
			// Here's where we use the addition operator defined in IAdditionOperators<T,T,T>
			total += rator.Current;

		return total;
	}
}

// Demo:

void Main()
{
	var point1 = new Point (1, 1);
	var point2 = new Point (2, 2);
	var point3 = new Point (3, 3);

	new[] { point1, point2, point3 }.SumEx().Dump ("sum of points");

	// The numeric types in .NET 7 all implement IAdditionOperators, so we can also use 
	// our SumEx method to sum any built-in numeric type:

	new[] { 1, 2, 3 }.SumEx().Dump ("sum of numbers (int)");
	new[] { 1.1, 2.2, 3.3 }.SumEx().Dump ("sum of numbers (double)");

	// The .NET numeric types implement a whole bunch of other new interfaces, encompassed
	// by INumberBase<TSelf> and INumber<TSelf>.
	// Click the following button to see how these interfaces are defined.
	new LINQPad.Controls.Button (
		"Show me what the INumberBase/INumber interfaces look like...",
		_ => Util.OpenILSpy (typeof (System.Numerics.INumberBase<>))).Dump();
}
