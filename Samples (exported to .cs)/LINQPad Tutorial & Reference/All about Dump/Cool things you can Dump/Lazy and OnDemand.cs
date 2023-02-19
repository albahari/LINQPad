// LINQPad Statements

// You can dump Lazy<T> objects and they'll materialize when you click the hyperlink:
new Lazy<int> (() => 123).Dump();

// Util.OnDemand does the same thing, except it lets you specify the text to display in the hyperlink:
Util.OnDemand ("Click me", () => 123).Dump();

// Util.OnDemand is useful for objects that are expensive to evaluate (or side-effecting). OnDemand is
// also exposed as an extension method on IEnumerable<T>:
"the quick brown fox".Split().OnDemand().Dump();