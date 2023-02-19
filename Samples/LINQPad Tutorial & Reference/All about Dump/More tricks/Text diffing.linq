<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

// When Util.Dif encounters strings that are similar, it performs a text dif:

string text1 = "The quick brown fox jumps over the lazy dog.";
string text2 = "The quick brown fox jumps right over the lazy dog";

Util.Dif (text1, text2).Dump();