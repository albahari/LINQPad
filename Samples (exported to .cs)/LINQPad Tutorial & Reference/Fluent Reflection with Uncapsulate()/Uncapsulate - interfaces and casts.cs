// LINQPad Statements

// Uncapsulate lets you call members of an interface just as you would statically.
// Even with explicitly implemented members:	

IInterface1 idemo = new Demo();
idemo.Uncapsulate().Test();                  // Calls IInterface1.Test()

var demo = new Demo();
((IInterface1)demo).Uncapsulate().Test();   // Calls IInterface1.Test()
((IInterface2)demo).Uncapsulate().Test();   // Calls IInterface2.Test()

// If the variable you're uncapsulating is not of the interface type, use CastTo:
new Demo().Uncapsulate().CastTo<IInterface1>().Test();

// OR:
new Demo().Uncapsulate().CastTo (typeof(IInterface1)).Test();

// You can also specify the interface name as a string (namespace not required).
// This comes in handy if the interface is not public:
new Demo().Uncapsulate().CastTo ("IInterface2").Test();

// To specify a generic type, use a backtick followed by the type parameter count:
new int[123].Uncapsulate().CastTo ("IList`1").Count.Dump();

interface IInterface1 { void Test(); }
interface IInterface2 { void Test(); }

class Demo : IInterface1, IInterface2
{
	void IInterface1.Test() => "Explicitly implemented interface method 1".Dump();
	void IInterface2.Test() => "Explicitly implemented interface method 2".Dump();
}