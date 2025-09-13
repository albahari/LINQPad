// LINQPad Statements

using System.Dynamic;

// Another useful application of Util.ToExpando is to force LINQPad to expand the properties
// of an object that you want to Dump.

// For example, sometimes you want to see the *properties* of a collection, rather than its elements.

var list = new List<int> { 1, 2, 3 };
Util.ToExpando (list).Dump();

Util.ToExpando (list, includePrivate:true).Dump ("with private members");