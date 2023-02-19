<Query Kind="Statements" />

// If you call Chart() with only an x-series, LINQPad will automatically group the x-series
// by itself and display the popularity of each element in descending order:

IEnumerable<char> letters = "the quick brown fox jumps over the lazy dog";
letters.Chart().Dump ("Letter popularity");

var random = new Random();
IEnumerable<int> numbers = Enumerable.Range (0, 1000).Select (i => random.Next (10));
numbers.Chart().Dump ("Random numbers - digit popularity");