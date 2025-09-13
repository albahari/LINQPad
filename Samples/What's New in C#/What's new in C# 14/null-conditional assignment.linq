<Query Kind="Statements">
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// This is a C# 14 preview feature. To work, you must enable C# Preview features in Settings > Scripts.
//
// You can now use the null-conditional (Elvis) operator with assignment expressions.

UriBuilder builder = null;
builder?.Host = "linqpad.net";   // Does nothing instead of crashing.

// In C# 13, this would result in "CS0131 The left-hand side of an assignment must be a variable, property or indexer".