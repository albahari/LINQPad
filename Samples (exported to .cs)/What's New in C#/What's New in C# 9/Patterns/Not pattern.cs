// LINQPad Statements

// The 'not' pattern is a great way to test for an object (not) being a type:

var s = new object();

if (s is not string) 
	"Not a string".Dump();

// Looks nicer than:

if (!(s is string))
	"Not a string".Dump();