// LINQPad Statements

using System.Globalization;

// You can display the difference between two objects with Util.Dif:

var americanCulture = new CultureInfo ("en-US");
var britishCulture = new CultureInfo ("en-GB");

Util.Dif (americanCulture, britishCulture).Dump();