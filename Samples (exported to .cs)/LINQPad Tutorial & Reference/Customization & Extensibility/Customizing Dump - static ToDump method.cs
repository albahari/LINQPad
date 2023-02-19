// LINQPad Program

// You can also define a static ToDump method in queries of type "C# Program".
// The static ToDump method fires on every call to Dump.

void Main()
{
	new Customer { FirstName = "Joe", LastName = "Bloggs", BirthDate = new DateTime (2000, 1, 1) }.Dump();
	DateTime.Now.Dump();
}

public class Customer
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
}

static object ToDump (object input)
{
	if (input is Customer c) 
		return new { c.FirstName, c.LastName };
		
	if (input is DateTime dt)
		return Util.WithStyle (dt, "color:purple");
	
	return input;
}

// Tip: if you define a static ToDump method in the "My Extensions" query, it will fire for all queries.
// For info on My Extensions, see query://../References_&_Namespaces/My_Extensions