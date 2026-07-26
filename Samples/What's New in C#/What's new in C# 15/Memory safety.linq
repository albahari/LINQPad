<Query Kind="Statements">
  <RuntimeVersion>11.0</RuntimeVersion>
</Query>

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// C# 15 begins redefining memory safety: the `unsafe` context now ties to operations that
// actually *access* unmanaged memory, rather than to the mere existence of pointer types.
// With the preview language version, the following no longer require an unsafe context:

int number = 42;
int* pointer = &number;              // declaring a pointer type & taking an address with &

int[] numbers = [10, 20, 30];
fixed (int* first = numbers)         // the fixed statement, which pins a variable
{
	int* buffer = stackalloc int[3]; // converting a stackalloc expression to a pointer

	// But operations that access the pointed-to memory still require an unsafe context.
	// These include dereferencing (*p), member access (p->member), element access (p[i])
	// and function-pointer invocation:
	unsafe { (*first).Dump ("First element (dereferencing still needs unsafe)"); }
}

int size = sizeof (Guid);            // sizeof applied to any unmanaged type
size.Dump ("sizeof(Guid)");
