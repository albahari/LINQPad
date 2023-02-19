// LINQPad Statements

using System.Dynamic

// You can use an ExpandoObject to build objects dynamically.
// For instance, suppose you want to dynamically create an object with 10 properties.
// Here's how you do it:

IDictionary<string,object> expando = new ExpandoObject();

for (int i = 0; i < 10; i++)
	expando [$"Column{i}"] = i;

expando.Dump ("expando");
Enumerable.Repeat (expando, 5).Dump ("expando list");

// Util.ToExpando converts an existing object it an expando that you can then customize:

var timeZone = Util.ToExpando (TimeZoneInfo.Local);
timeZone.Remove ("StandardName", out _);                         // Remove a property
timeZone.TryAdd ("My Extra Property", Util.Highlight ("foo"));   // Add a property
timeZone.Dump ("TimeZone");