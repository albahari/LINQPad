// LINQPad Statements

// Constructing a new object is just like calling a static member (see preceding sample)
// whose name is @new.

Demo myClass = Uncapsulate<Demo>().@new (1);	

// or if the type is inaccessible:
var myClass2 = Uncapsulate ("Demo").@new (2);	

// You can also use @new as an instance method (i.e., on an existing object).
// It will then instantiate a new object of the same type.
myClass.Uncapsulate().@new (3);

class Demo
{
	static string _privateField = "static private value";

	private Demo (int foo) => ("Private constructor! " + foo).Dump();
}