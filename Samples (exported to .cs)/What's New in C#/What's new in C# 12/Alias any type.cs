// LINQPad Statements

// In C# 12, the using directive can alias any type, including arrays and tuples with named elements.

using NumberList = double[];
using Point = (int X, int Y);    // Legal (but not necessarily *good*!)

NumberList numbers = { 2.5, 3.5 };

Point p = (3, 4);
p.Dump();

// Note that with the same amount of code, you could implement Point as a record!

Point2 p2 = new (3, 4);
p2.Dump();

record Point2 (int X, int Y);   // No more work than declaring a type alias,
                                // but safer, more flexible & friendly to refactoring.
