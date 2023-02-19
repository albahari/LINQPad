<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

// A nameof expression can now access method parameters when applying attributes
// The main use-case for this is in conjunction with CallerArgumentExpression
// ( see query://../What's_new_in_C#_10/CallerArgumentExpression.linq )

void Assert (
	bool condition,
	[CallerArgumentExpression (nameof(condition))] string message = null)
{
	Debug.Assert (condition, message);
}

void Main()
{
	Assert (2 + 2 == 5);
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/extended-nameof-scope.md

