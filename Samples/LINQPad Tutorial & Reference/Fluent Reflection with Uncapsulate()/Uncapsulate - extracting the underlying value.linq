<Query Kind="Statements" />

var uncap = new Demo().Uncapsulate();

// You can extract an uncapsulated object's underlying value with a C# cast.
// Implicit and explicit casts both work:

DateTime thisWorks = uncap.Now;             // Implicit cast to DateTime
var thisAlsoWorks = (DateTime) uncap.Now;   // Explicit cast to DateTime

// If you don't know the type and just want a System.Object, call .ToObject():

object obj = uncap.Now.ToObject();
obj.Dump();
$"obj is of type {obj.GetType().Name}".Dump();

class Demo
{
	private DateTime Now => DateTime.Now;
}