<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
  <RuntimeVersion>11.0</RuntimeVersion>
</Query>

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// Union types (sum types) let you declare a closed set of alternatives for a single type.
// For more info, see https://devblogs.microsoft.com/dotnet/csharp-15-union-types/

// To declare a union, use the union keyword with a list of possible types:
union IntOrString (int, string);

void Main()
{
	// There's an implicit conversion from each of the member types to the Union:
	IntOrString u1 = 1;
	IntOrString u2 = "hello, world";
	
	// The compiler prevents invalid conversions:
	// IntOrString result3 = DateTime.Now;  // compile-time error.
	
	// You can access the untyped (object-typed) value as follows:
	u1.Value.Dump(); u2.Value.Dump();

	// Here's how to access its value in a type-safe manner:	
	if (u1 is int n)
		n.Dump ($"result1 is an int");

	if (u2 is string s)
		s.Dump ($"result2 is a string");
	
	// The compiler won't let you match with an invalid type:
	// if (result2 is DateTime d)
	//   d.Dump ("result2 is a DateTime");  // compile-time error

	for (int i = 0; i < 10; i++)
	{
		// A switch expression is also type-safe and protects you from forgetting
		// a case (the compiler warns you unless all types are covered).
		string msg = RandomIntOrString() switch
		{
			int number => $"Integer: {number}",
			string word => $"String: {word}",
			null => "null".Dump()   // we need this because string is nullable
		};
		msg.Dump();
	}
}

IntOrString RandomIntOrString() => Random.Shared.Next (3) switch
{
	0 => 123,
	1 => "hello",
	// We are allowed to assign null to a union if one or more of the union's 
	// types is nullable (in our case, string)
	_ => null
};

namespace System.Runtime.CompilerServices
{
	// The current .NET 11 previews require that we define this polyfill ourselves. This will be fixed in future previews.
	[AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
	public sealed class UnionAttribute : Attribute;

	public interface IUnion
	{
		object Value { get; }
	}
}