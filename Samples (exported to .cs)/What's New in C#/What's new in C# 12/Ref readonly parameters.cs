// LINQPad Program

using System.Globalization;

// TLDR: 'ref readonly' is just like 'in', but generates more warnings.
// Stick with using 'in' if you don't like the ugliness of 'ref readonly'
// (assuming that you need 'in' at all - which you probably don't).

// Perspective warning: To keep things simple, we will use this 48-byte struct to demonstrate
// the feature. Keep in mind that with a struct this small, there is only ~1 nanosecond performance
// difference between passing by value and reference! To achieve a ~10 nanosecond difference, 
// you need to add at least 1000 bytes to the length of the struct.

record struct Point (decimal X, decimal Y, decimal Z);

// C# 12 introduces the 'ref readonly' parameter modifier, a micro-optimization feature
// that lets you pass values by reference while preventing modifications to the variable.
// This is very similar to the 'in' modifier introduced in C# 7.2 - in the following
// example, the IL is the same whether we call the In method or the RefReadonly method:

void Main()
{
	Point p = new (4.5m, 7.31m, -1.3m);
	In (p);
	RefReadonly (ref p);
}

void In (in Point value)
{
	value.Dump();
	// value.X++;   // not allowed
}

void RefReadonly (ref readonly Point value)
{
	value.Dump();
	// value.X++;   // not allowed
}

// In both cases, variable p is passed to the method efficiently - without creating a copy.
// In other words, variables 'p' and 'value' end up referring to the same memory location.

// But now consider what happens when you pass a constant or expression into the methods
// instead of a variable:

void InefficientIn()
{
	In (new Point (4.5m, 7.31m, -1.3m));
}

// Because the expression is not backed by a memory location, the compiler must copy the struct
// (passing by value). The code still works, but we miss out on the optimization that we set out
// to achieve. Now, let's try the same thing with ref readonly:

void InefficientRefReadonly()
{
	RefReadonly (new Point (4.5m, 7.31m, -1.3m));   // Generates a warning
}

// Again it works, but the compiler now generates a warning.
// This is the main advantage of 'ref readonly' over 'in'.

// The compiler also generates a warning when you call a 'ref readonly' method without the 'ref' modifier.

void OptionalOrNot()
{
	Point p = new (4.5m, 7.31m, -1.3m);
	
	In (in p);  // OK 
	In (p);     // OK (still passes by reference)
	
	RefReadonly (ref p);     // OK
	RefReadonly (p);         // Works (still passes by reference) - but generates a warning
}

// To make it easy to refactor existing 'in' parameters into 'ref readonly' parameters,
// you can call 'ref readonly' methods with the old 'in' annotation:

void Transition()
{
	Point p = new (4.5m, 7.31m, -1.3m);
	RefReadonly (in p);
}

// For more info, see https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/ref-readonly-parameters