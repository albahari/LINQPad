// LINQPad Statements

object x = new Uri ("http://www.linqpad.net");

// In C# 10, property patterns can reference nested members:
(x is Uri { Scheme.Length:4 }).Dump();

// Previously, you had to do this:
(x is Uri { Scheme: { Length: 4 }}).Dump();

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/extended-property-patterns.md