// LINQPad Statements

// A function pointer in C# 9 lets you point directly to a static method without the 
// indirection of a delegate, and is intended for high-performance interop scenarios.

// The following function pointer matches a method that accepts a string and returns an int.
// We can get the address of a static method with the & operator:
delegate*<string, int> functionPointer = &GetLength;

// Here's how to invoke it:
int length = functionPointer ("Hello, world");
length.Dump();

// A function pointer is a pointer, not an object:
((nuint)functionPointer).Dump ("Address in memory");

static int GetLength (string s) => s.Length;
