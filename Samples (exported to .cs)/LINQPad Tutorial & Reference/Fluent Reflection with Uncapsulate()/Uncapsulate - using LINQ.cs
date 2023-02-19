// LINQPad Statements

// To query a collection of private objects, call ToDynamicSequence() on the collection
// and assign the result to IEnumerable<dynamic>:
IEnumerable<dynamic> sequence = new Demo().Uncapsulate().Customers.ToDynamicSequence();

sequence.Dump ("Customers");

// Now we have something that we can run LINQ queries over:	
var query =
	from item in sequence
	orderby (string) item._lastName   // Remember to cast the elements!
	select item;
	
query.Dump ("Ordered by _lastName");

class Demo
{
	Customer[] Customers => Enumerable.Range (0, 6).Select (_ => new Customer()).ToArray();

	class Customer
	{
		string _firstName = "Joe" + _random.Next (10);
		string _lastName = "Bloggs" + _random.Next (10);

		static Random _random = new Random();
	}
}