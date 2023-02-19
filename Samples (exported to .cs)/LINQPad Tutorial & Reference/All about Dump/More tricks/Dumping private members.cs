// LINQPad Statements

using System.Dynamic

// The 'includePrivate' parameter lets you include private fields and properties when dumping:

new StringBuilder ("test").Dump (includePrivate:true);

// To access private fields and properties programmatically, call the Uncapsulate() extension method:
// query://../../Fluent_Reflection_With_Uncapsulate()