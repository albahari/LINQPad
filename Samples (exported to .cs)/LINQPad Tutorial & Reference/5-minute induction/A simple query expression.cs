// LINQPad Expression

// Now for a simple LINQ-to-objects query expression (notice no semicolon):

from word in "The quick brown fox jumps over the lazy dog".Split()
orderby word.Length
select word


// Feel free to edit this... (no-one's watching!)
// The inbuilt samples cannot be overwritten.
//
// Tip:  You can execute part of a query by highlighting it, and then pressing F5.