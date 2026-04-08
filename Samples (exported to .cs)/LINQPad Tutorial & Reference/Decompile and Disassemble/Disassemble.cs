// LINQPad Statements

// The Disassemble() extension method shows the IL (Intermediate Language) for a method.
// This is useful for understanding what the JIT compiler sees, and for low-level diagnostics.

typeof (string).GetMethod ("Contains", new[] { typeof (string) })
	.Disassemble().Dump ("IL for string.Contains(string)");

// You can also disassemble your own methods:

typeof (Demo).GetMethod ("Add")
	.Disassemble().Dump ("IL for Demo.Add");

class Demo
{
	public static int Add (int a, int b) => a + b;
}
