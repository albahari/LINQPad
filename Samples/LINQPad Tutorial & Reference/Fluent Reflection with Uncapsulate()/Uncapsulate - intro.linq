<Query Kind="Statements" />

// Accessing an object's private fields, properties and methods is useful for diagnostics and debugging.
// LINQPad's Uncapsulate() extension method lets you do this without messing with Reflection.

var demo = new Demo();
int privateValue = demo.Uncapsulate()._private;         // Much easier than using reflection!
privateValue.Dump ("We can access private members!");

// Let's now reach into System.Uri's private fields:

Enum flags = new Uri ("http://test").Uncapsulate()._syntax._flags.Dump ("URI flags");

class Demo
{
	int _private = 123;
}