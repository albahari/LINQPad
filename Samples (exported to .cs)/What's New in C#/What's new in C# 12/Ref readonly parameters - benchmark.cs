// LINQPad Program

#load "BenchmarkDotNet"

using System.Globalization
using BenchmarkDotNet.Attributes
using System.Runtime.CompilerServices

// This shows the performance difference between passing a 48-byte struct by value vs reference.
// Passing by reference is about twice as fast - which sounds like a lot - but amounts to only
// a ~1 nanosecond gain on a modern desktop (or ~5ns on an Azure Web App Standard S1 service plan).



unsafe struct Point
{
	public decimal X, Y, Z;
	public Point (decimal x, decimal y, decimal z) => (X, Y, Z) = (x, y, z);

	// To get a more meaningful performance difference, you need to enlarge the struct.
	// public fixed byte Buffer [1000];
}

Point p = new (1m, 2m, 3m);

void Main()
{
	RunBenchmark();
}

[Benchmark]
public void TestByReference()
{
	ByReference (in p);
}

[Benchmark]
public void TestByValue()
{
	ByValue (p);
}

int _accumulator;

// Note that the performance is the same for 'in', 'ref' and 'ref readonly'.
[MethodImpl (MethodImplOptions.NoInlining)]
unsafe void ByReference (ref readonly Point value)
{
	// Consume a field in the struct, to ensure that the JIT optimizer doesn't
	// factor away the method entirely. Keep the operation simple so that it won't
	// add significantly to the benchmark time.
	_accumulator += (value.X == 0 ? 0 : 1);
}

[MethodImpl (MethodImplOptions.NoInlining)]
unsafe void ByValue (Point value)
{
	// Consume a field in the struct, to ensure that the JIT optimizer doesn't
	// factor away the method entirely. Keep the operation simple so that it won't
	// add significantly to the benchmark time.
	_accumulator += (value.X == 0 ? 0 : 1);
}