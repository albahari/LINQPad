// LINQPad Statements

// In C# 14, you can now use the null-conditional (Elvis) operator with assignment expressions.

UriBuilder builder = null;
builder?.Host = "linqpad.net";   // Does nothing instead of crashing.

// In C# 13, this would result in "CS0131 The left-hand side of an assignment must be a variable, property or indexer".