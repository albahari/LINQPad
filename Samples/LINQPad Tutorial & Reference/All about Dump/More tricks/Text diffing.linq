<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

// Util.Dif can also perform text diffing:

string text1 = "The quick brown fox jumps over the lazy dog.";
string text2 = "The quick brown fox jumps right over the lazy dog";

Util.Dif (text1, text2).Dump();

// This works with large documents too, such as source files.

