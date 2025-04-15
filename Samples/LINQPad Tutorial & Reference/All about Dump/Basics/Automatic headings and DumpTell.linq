<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// You can tell LINQPad to automatically generate headings via a toolbar button (or Ctrl+Shift+H).
// The description is then populated automatically via C#'s [CallerArgumentExpression] feature.

"the quick brown fox".Split().Dump();

TimeZoneInfo.Local.Dump();

// LINQPad won't emit the heading when dumping simple literals or constructor calls.

"This won't generate an automatic heading".Dump();
new StringBuilder ("Neither will this").Dump();

// You can also invoke the auto-heading behavior by calling DumpTell() instead of Dump().