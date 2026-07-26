<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
</Query>

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// Union types are good for writing parsers:

public union Token (IntLiteral, FloatLiteral, Identifier, Operator);

record IntLiteral (int Value);
record FloatLiteral (double Value);
record Identifier (string Name);
record Operator (char Symbol);

void Main()
{
	foreach (var token in Tokenize ("foo = 42 + 3.14"))
		TokenToString (token).Dump();
}

IEnumerable<Token> Tokenize (string input) =>
	from word in input.Split (' ', StringSplitOptions.RemoveEmptyEntries)
	select (Token)
	(
		int.TryParse (word, out var i)
			? new IntLiteral (i) :
		double.TryParse (word, out var d) 
			? new FloatLiteral (d) :
		word.Length == 1 && !char.IsLetter (word [0]) 
			? new Operator (word [0])
			: new Identifier (word)
	);

string TokenToString (Token token) => token switch
{
	// Again, we get the protection of exhaustive pattern matching.
	IntLiteral i   => $"Int({i.Value})",
	FloatLiteral f => $"Float({f.Value})",
	Identifier id  => $"Id(\"{id.Name}\")",
	Operator op    => $"Op('{op.Symbol}')"
};

// Without unions, we could implement TokenToString by overriding the ToString()
// method on each of the four types (or defining a IPrintable interface).
// But this works only if we *own the types*.
// If not, we'd need to implement the *visitor pattern* which is much more complex.


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