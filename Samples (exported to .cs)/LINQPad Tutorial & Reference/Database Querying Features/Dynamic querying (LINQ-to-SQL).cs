// LINQPad Statements

// You can execute a SQL query into IEnumerable<dynamic> with LINQPad's ExecuteQueryDynamic method.
//
// (You will need a LINQ-to-SQL connection to make this script work).

var results = ExecuteQueryDynamic ("select * from Customers where [Contact Name] like {0}", "%ann%").ToArray();
results.Dump();    // results is IEnumerable<dynamic>

var city = (string) results.First().City;                  // dynamic binding
var postCode = (string) results.First() ["Postal Code"];   // this also works

new { city, postCode }.Dump();
