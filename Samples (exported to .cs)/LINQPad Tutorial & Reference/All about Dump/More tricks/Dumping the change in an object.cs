// LINQPad Statements

using System.Globalization
using System.Windows.Forms

// There's also a Util.Snapshot method to 'snapshot' an object so you can later compare it with itself.

var numbers = Enumerable.Range (0, 30).ToList();
var snapshot = Util.Snapshot (numbers);               // Take a snapshot

numbers[10] *=10;                                     // Make changes to the object
numbers.Insert (20, 100000);

Util.Dif (snapshot, numbers).Dump();