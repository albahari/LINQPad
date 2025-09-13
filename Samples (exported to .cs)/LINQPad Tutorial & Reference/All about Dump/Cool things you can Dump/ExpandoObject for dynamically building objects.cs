// LINQPad Statements

using System.Dynamic;

// You can use an ExpandoObject to build objects dynamically.
// For instance, suppose you want to dynamically create an object with 10 properties.
// Here's how you do it:

IDictionary<string,object> expando = new ExpandoObject();

for (int i = 0; i < 10; i++)
	expando [$"Column{i}"] = i;

expando.Dump ("expando");
Enumerable.Repeat (expando, 5).Dump ("expando list");
