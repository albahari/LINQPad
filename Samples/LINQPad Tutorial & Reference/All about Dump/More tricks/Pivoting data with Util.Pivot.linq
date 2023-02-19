<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

// You can swap rows and columns in the output with Util.Pivot:

var people = new[]
{
	new { FirstName = "Alice", LastName = "Brown" },
	new { FirstName = "Bob", LastName = "Black" },
};
	
            people. Dump ("Standard list");
Util.Pivot (people).Dump ("Pivoted list");

// You can also pivot non-enumerable objects:

            new { X = 1, Y = 2, Z = 3} .Dump ("Standard object");
Util.Pivot (new { X = 1, Y = 2, Z = 3}).Dump ("Pivoted object");