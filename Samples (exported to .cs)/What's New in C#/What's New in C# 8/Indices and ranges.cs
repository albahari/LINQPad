// LINQPad Statements

// Indices and ranges provide a succinct syntax for accessing single elements or ranges in a sequence.

var words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumped",   // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0

$"The last word is {words[^1]}".Dump();

words[1..4]    .Dump ("words[1..4]");
words[^2..^0]  .Dump ("words[^2..^0]");
words[..]      .Dump ("words [..]");
words[..4]     .Dump ("words[..4]");
words[6..]     .Dump ("words[6..]");

Range phrase = 1..4;
var text = words[phrase].Dump ("range");

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges