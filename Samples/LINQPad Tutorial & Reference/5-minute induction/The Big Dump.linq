<Query Kind="Statements" />

// LINQPad's "Dump" extension method will eat just about anything!

123.Dump();

Regex.Match ("my favorite color is...", "colou?r").Dump();   // LINQPad is great for Regex testing!

// Dump accepts an optional title for formatting:

TimeZoneInfo.Local.Dump ("Bet you never knew this type existed!");

// You can get LINQPad to automatically generate a title by calling DumpTell() instead of Dump:
(1 + 1).DumpTell();        // Tip: there's a toolbar button to make DumpTell() the default.

// Dump returns exactly what it was given, so you can sneakily inject
// a Dump (or even many Dumps) *within* an expression. This is useful
// for monitoring a query as it progresses:

new[] { 11, 5, 17, 7, 13 }  .Dump ("Prime numbers")
   .Where (n => n > 10)     .Dump ("Prime numbers > 10")
   .OrderBy (n => n)        .Dump ("Prime numbers > 10 sorted")
   .Select (n => n * 10)    .Dump ("Prime numbers > 10 sorted, times 10!");

// Or you can do this:
DateTime now = DateTime.Now.Dump();