<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

// Lambda expressions now support implicit typing, so can be used in var expressions:
var action = () => {};
var func = () => 123;
var isLower = (string input) => input.ToLower() == input;

// The compiler maps these lambdas to the Func or Action delegates:
action.GetType().Name.Dump();
func.GetType().Name.Dump();
isLower ("test").Dump();

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/lambda-improvements.md