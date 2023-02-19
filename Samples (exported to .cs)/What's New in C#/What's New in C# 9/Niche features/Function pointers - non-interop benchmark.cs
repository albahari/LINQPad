// LINQPad Program

#load "BenchmarkDotNet"

#r: "nuget: BenchmarkDotNet"

using BenchmarkDotNet.Attributes
using System.Threading.Tasks
using System.Runtime.CompilerServices
using BenchmarkDotNet.Running

// In non-interop scenarios, the performance gain from function pointers is negligible.
//
// In the Benchmark output, divide all the outcomes by a million (so milliseconds becomes
// nanoseconds; this is because we perform each invocation a million times in each test).
// The end result is that the function pointer is barely faster than the delegate.

void Main()
{
	RunBenchmark();
}

[Benchmark]
public void WithDelegate()
{
	Action<int> action = VerySimpleMethod;
	for (int i = 0; i < 1000000; i++) action (i);
}

[Benchmark]
public unsafe void WithFunctionPointer()
{
	delegate*<int, void> increment = &VerySimpleMethod;
	for (int i = 0; i < 1000000; i++) increment (i);
}

[Benchmark]
public void WithDirectCall()
{
	for (int i = 0; i < 1000000; i++) VerySimpleMethod (i);
}

static int _x;
[MethodImpl (MethodImplOptions.NoInlining)]
public static void VerySimpleMethod (int i) => _x++;