// LINQPad Statements

using System.ComponentModel

// You can now apply attributes to lambdas:

Action a1 = [Description("test")] () => { };
Action a2 = [return: Description("test")] () => { };

// The attributes are applied to the method to which the delegate points:
a1.GetMethodInfo().GetCustomAttributes().Dump();
a2.GetMethodInfo().ReturnParameter.GetCustomAttributes().Dump();

// To avoid syntactical ambiguity, parentheses are always required on the lambda, even with a single argument:
Action<int> a3 = [Description("test")] (x) => { };

// Attributes are not permitted on expression-tree lambdas.

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/lambda-attributes.md
