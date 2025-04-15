// LINQPad Statements

using System.Dynamic

// Util.ToExpando converts an existing object it an expando that you can then customize:

var timeZone = Util.ToExpando (TimeZoneInfo.Local);
timeZone.Remove ("StandardName", out _);                         // Remove a property
timeZone.TryAdd ("My Extra Property", Util.Highlight ("foo"));   // Add a property
timeZone.Dump ("TimeZone");

// Util.ToExpando has optional parameters for including/excluding members, and ordering members
// alphabetically. There's even an includePrivate option to include private fields & properties.

Util.ToExpando (TimeZoneInfo.Local, include:"Id, DisplayName", nameOrder:true).Dump();

