// LINQPad Program

using System.Net.Http;
using System.Net.Sockets;

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// Unions declarations can include type parameters.
// The following "standard" unions are a bit like the Action/Func delegates.
// (In future .NET 11 previews, they'll be included by deafult)

union Union<T1, T2> (T1, T2);
union Union<T1, T2, T3> (T1, T2, T3);
union Union<T1, T2, T3, T4> (T1, T2, T3, T4);
union Union<T1, T2, T3, T4, T5> (T1, T2, T3, T4, T5);

void Main()
{
	Union<int, string> u = 123;
	u.Dump();
	
	for (int i = 0; i < 10; i++)
	{
		string msg = RandomIntOrString() switch
		{
			int number => $"Integer: {number}",
			string word => $"String: {word}"
		};
		msg.Dump();
	}
	
	// Limitations:
	//
	// - Because type parameters are an ordered list and not a set,
	//   Union<T1, T2> is not the same as Union<T2, T1>.
	//
	// - There's no support for composition & chaining, i.e.,
	//   Union<T1, Union<T2, T3>> does not collapse into Union<T1, T2, T3>.
}

Union<int, string> RandomIntOrString()
{
	if (Random.Shared.Next (2) == 0)
		return 123;
	else
		return "test";
}


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