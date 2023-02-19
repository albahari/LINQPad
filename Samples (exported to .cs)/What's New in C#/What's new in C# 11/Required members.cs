// LINQPad Program

using System.Diagnostics.CodeAnalysis

// NB: This demo requires .NET 7+   https://dotnet.microsoft.com/en-us/download/dotnet/7.0
//
// The 'required' modifier on a property indicates that the property must be initialized during construction.
// This feature lets you do away with constructors altogether, and rely just on object initializers.

void Main()
{
	new Point { X = 2, Y = 3 }.Dump();  // OK
	//new Point { X = 2 }.Dump();       // Prohibited by compiler (we haven't initialized Y)
	//new Point().Dump();               // Prohibited by compiler (we haven't initialized X or Y)
}

class Point
{
	public required int X { get; set; }
	public required int Y { get; set; }	
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/required-members.md