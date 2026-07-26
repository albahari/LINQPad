<Query Kind="Program">
  <RuntimeVersion>11.0</RuntimeVersion>
</Query>

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// *** This sample requires .NET 11 PREVIEW 5 or later ***

// A *closed* class can be derived from only within its declaring assembly, which fixes the
// set of direct descendants at compile time. This lets a switch expression that handles each
// descendant be exhaustive - with no default arm - much like a union, but based on inheritance.

closed record GateState;
record Closed : GateState;
record Open (float Percent) : GateState;

void Main()
{
	Describe (new Closed()).Dump();
	Describe (new Open (42)).Dump();
}

string Describe (GateState state) => state switch
{
	// No default arm needed: the compiler knows every direct descendant of GateState,
	// and warns you if you forget one.
	Closed => "closed",
	Open (var percent) => $"{percent}% open"
};

// A closed class is implicitly abstract and can't be combined with sealed, static or abstract.
// Derivation isn't transitive: a non-closed descendant can still be derived from in other
// assemblies. To extend exhaustiveness down the hierarchy, mark intermediate descendants closed too.

namespace System.Runtime.CompilerServices
{
	// The current .NET 11 previews require that we define this polyfill ourselves. This will be fixed in future previews.
	[AttributeUsage (AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class ClosedAttribute : Attribute;
}
