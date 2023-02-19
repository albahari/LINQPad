// LINQPad Expression

/* Sometimes you'll want to test queries that you've written in Visual Studio. Here are a few tips.

First, you can get LINQPad to query the Entity Framework or LINQ-to-SQL typed datacontext that you've
created in Visual Studio. Click 'Add Connection' and click the second radio button ("Use a data context
from your own assembly").

Second, you might have noticed that in LINQPad, a query starts like this:

	var query = Customers...
	
whereas in Visual Studio, they start like this:

	var query = dataContext.Customers...

The good news is that you can use the 'dataContext' variable in your LINQPad queries, too. Just do this:

	var dataContext = this;
	var query = dataContext.Customers...

This works because LINQPad *subclasses* your data context. Hence 'this' refers to the data context.

*/