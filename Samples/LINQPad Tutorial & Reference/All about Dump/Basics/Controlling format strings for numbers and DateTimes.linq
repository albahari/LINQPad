<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

// Sometimes it's useful to apply custom format strings when dumping numeric and date/time types,
// LINQPad lets you specify global defaults in Edit | Preferences > Formatting.
// You can also provide format strings with each call to Dump:
DateTime.Now.Dump (new DumpOptions { FormatStrings = new DumpFormatStrings { DateTime = "yyyy-MM-dd" }});

// Alternatively:
DumpOptions.Default.FormatStrings.DateTime = "dd-MM-yy";
DateTime.Now.Dump();

// To format numbers with thousands separators:
DumpOptions.Default.FormatStrings.IntegralNumber = DumpFormatStrings.Constants.IntegralNumberWithGroupSeparator;
DumpOptions.Default.FormatStrings.RealNumber = DumpFormatStrings.Constants.RealNumberWithGroupSeparator;

1234567.89.Dump();