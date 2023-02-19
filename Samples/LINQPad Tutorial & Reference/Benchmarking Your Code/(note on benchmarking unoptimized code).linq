<Query Kind="Statements" />

// The "BenchmarkDotNet.linq" script that LINQPad #loads includes a directive to enable compiler/JIT
// optimizations by default, so that you're always benchmarking optimized code.

// You can override this and benchmark in "DEBUG" mode by adding the following directive to your script:
#LINQPad optimize-

// This allows you to set breakpoints should you need to debug an issue that arises only during benchmarking.

// Highlight the following code and press Ctrl+Shift+B to benchmark unoptimized code:
// Comment out the directive above to compare performance with optimized code.

long l = 0;
for (int i = 0; i < 10000; i++)
{
	for (int j = 0; j < 10000; j++)
	{
		l++;
	}
}
