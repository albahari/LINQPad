// LINQPad Statements

using System.Runtime.CompilerServices;

// When compiling methods, C# emits a flag that instructs the runtime to initialize local variables
// to their default 'zero' values (by clearing the memory).
//
// From C# 9, you can tell C# not to emit this flag by applying the [SkipLocalsInit] attribute.
// This can improve performance slightly with large stackallocs.

Foo();

[SkipLocalsInit]      // NB: This requires .NET 5+. It will not compile in .NET 3.1.
unsafe void Foo()
{
	int local;
	int* ptr = &local;

	Console.WriteLine (*ptr);     // Uninitialized memory

	int* a = stackalloc int [20];
	for (int i = 0; i < 20; ++i) Console.WriteLine (a [i]);   // Uninitialized memory
}
