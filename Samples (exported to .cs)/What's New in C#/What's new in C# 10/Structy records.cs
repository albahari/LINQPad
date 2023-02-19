// LINQPad Statements

// Records can now be declared as value types with the 'struct' modifier.

new R1 (3, 4).GetType().IsValueType.Dump();
new R2 (3, 4).GetType().IsValueType.Dump();

record        R1 (double X, double Y);    // classy record
record struct R2 (double X, double Y);    // structy record

// For completeness, you can also use 'class' as a modifier.
// The following two definitions are equivalent:

record        R3 (double X, double Y);    // classy record
record class  R4 (double X, double Y);    // classy record

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/record-structs.md