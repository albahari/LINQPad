// LINQPad Statements

using System.Globalization;

// When writing classes, you can easily tell LINQPad which properties/fields to include when dumped,
// by writing a ToDump method. You can even take over the HTML rendering entirely. This is covered 
// in more detail in https://www.linqpad.net/CustomizingDump.aspx

// Here's an example of writing a ToDump method on a class that excludes the 'FirstName' field:
new Customer ("Joe", "Bloggs", new DateTime (2000, 1, 1)).Dump();

// More ways to do it:
new Customer2 ("Joe", "Bloggs", new DateTime (2000, 1, 1)).Dump();
new Customer3 ("Joe", "Bloggs", new DateTime (2000, 1, 1)).Dump();
new Customer4 ("Joe", "Bloggs", new DateTime (2000, 1, 1)).Dump();

public record class Customer (string FirstName, string LastName, DateTime BirthDate)
{
	object ToDump() => new { LastName, BirthDate };    // Private, so it doesn't pollute your type
}

public record class Customer2 (string FirstName, string LastName, DateTime BirthDate)
{
	object ToDump() => Util.ToExpando (this, exclude:"FirstName");
}

public record class Customer3 (string FirstName, string LastName, DateTime BirthDate)
{
	public CultureInfo Culture = CultureInfo.CurrentCulture;
	
	object ToDump() => new DumpContainer (this, options =>
	{
		options.MembersToExclude = "FirstName";
		options.MaxDepth = 1;   // prevent Culture property from expanding
		options.AlphabetizeMembers = true;
		options.FormatStrings.DateTime = "yyyy-MM-dd";
	});
}

public record class Customer4 (string FirstName, string LastName, DateTime BirthDate)
{
	// In this example, we don't use any LINQPad-specific methods, so this class could
	// be defined in an external assembly that doesn't reference LINQPad.Runtime.dll.
	object ToDump() => new XElement ("LINQPad.HTML",
		new XElement ("div", new XAttribute ("style", "color:violet; font-size:150%"),
		   FirstName + " " + LastName));
}

// You can also write a static ToDump method in the 'My Extensions' script that fires on all objects.
// static object ToDump (object input) => ...
// See https://www.linqpad.net/CustomizingDump.aspx for more info.