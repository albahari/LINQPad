<Query Kind="Statements">
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

// A method parameter to which you apply the [CallerArgumentExpression] attribute "sucks up" the argument's source code:
Print (Math.PI * 2);

// This even includes comments:
Print (Math.PI /* (π) */ * 2);

// A great application is assertion libraries:
Assert (2 + 2 == 5);

void Print (double number, [CallerArgumentExpression("number")] string argumentSourceCode = null)
{
	$"{argumentSourceCode} evaluates to {number}".Dump();	
}

void Assert (bool condition, [CallerArgumentExpression ("condition")] string message = null)
{
	Debug.Assert (condition, message);
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/caller-argument-expression.md
