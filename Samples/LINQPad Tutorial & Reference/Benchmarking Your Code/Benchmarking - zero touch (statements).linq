<Query Kind="Statements" />

// With the script language set to "C# Statements", you can do basic benchmarking.
//
// Select the following lines of code and press Ctrl+Shift+B / Shift-Command-B to find out how long it takes to
// call ToUpper on a string:

string s1 = "The quick brown fox jumps over the lazy dog.";
string s2 = s1.ToUpper();

// By default, LINQPad ignores calls to Dump during benchmarking, to minimize impact on results.

// Now let's see how long it takes to obtain an uncontended lock:

var locker = new object();
lock (locker) { }

// We will improve this test in the next demo...