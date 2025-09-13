// LINQPad Statements

using System.Drawing;

// When constructing objects, C# 9 lets you omit the type name when it can be easily determined
// from an assignment. This feature is handy when initializing fields:

Point p;

p = new (3, 5);
p.Dump();