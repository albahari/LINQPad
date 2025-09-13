// LINQPad Statements

// When writing classes, you can easily tell LINQPad which properties/fields to include when dumped,
// by writing a ToDump method. You can even take over the HTML rendering entirely. This is all covered 
// in detail in https://www.linqpad.net/CustomizingDump.aspx

// Here's an example of writing a ToDump method on a class that excludes the 'BirthDate' field:
new Customer { FirstName = "Joe", LastName = "Bloggs", BirthDate = new DateTime (2000, 1, 1) }.Dump();

// Another way to do it:
new Customer2 { FirstName = "Joe", LastName = "Bloggs", BirthDate = new DateTime (2000, 1, 1) }.Dump();

// Yet another solution:
new Customer3 { FirstName = "Joe", LastName = "Bloggs", BirthDate = new DateTime (2000, 1, 1) }.Dump();

public class Customer
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }

	object ToDump() => new { FirstName, LastName };    // Private, so it doesn't pollute your type
}

public class Customer2
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }

	object ToDump() => Util.ToExpando (this, exclude:"BirthDate");
}

public class Customer3
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }

	object ToDump() => new XElement ("LINQPad.HTML",
		new XElement ("div", new XAttribute ("style", "color:violet; font-size:150%"),
		   FirstName + " " + LastName));
}

// You can also write a static ToDump method in the 'My Extensions' script. See https://www.linqpad.net/CustomizingDump.aspx