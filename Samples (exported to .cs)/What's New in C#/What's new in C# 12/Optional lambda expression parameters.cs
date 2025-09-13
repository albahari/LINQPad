// LINQPad Statements

using System.Globalization;

// Just as ordinary methods can have optional parameters:
bool IsLower (string input, CultureInfo culture = null) => input.ToLower (culture) == input;
	
// so now can lambda expressions:	
var isLower = (string input, CultureInfo culture = null) => input.ToLower (culture) == input;
	
IsLower ("test").Dump();
isLower ("test").Dump();

// This feature is useful with libraries such as ASP.NET Minimal API.

// See also script://../What's_new_in_C#_10/Lambda_expressions/var_with_lambdas