<Query Kind="Statements" />

// C# 9 introduced the 'with' keyword to enable nondestructive mutation with records.
// In C# 10, the same trick works with anonymous types:

var cs9 = new
{
	Name = "C#",
	Version = 9
};
var cs10 = cs9 with { Version = 10 };
cs10.Dump();