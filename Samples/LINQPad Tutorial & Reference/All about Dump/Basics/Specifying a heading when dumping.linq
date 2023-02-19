<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

/* You can specify a heading when dumping by passing a string argument to Dump: */

"Hello, world".Dump ("Greeting");

"the quick brown fox".Split().Dump ("A list of words");

TimeZoneInfo.Local.Dump ("Local time");