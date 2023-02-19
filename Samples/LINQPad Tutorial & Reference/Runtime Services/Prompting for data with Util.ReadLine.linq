<Query Kind="Statements" />

// Console.ReadLine is the simplest way to prompt for data:
Console.ReadLine().Dump();

// There's a more powerful version of ReadLine in the Util class:
Util.ReadLine<int> ("Enter the magic number").Dump();

// Notice the <int> type parameter. This automatically parses the result into an integer.
// You can also specify a default value:
Util.ReadLine<int> ("Enter the magic number", 42).Dump();

// If you specify an enum as a type parameter, you'll get a ComboBox:
Util.ReadLine<ConsoleColor> ("Choose a color").Dump();

// You can also provide a list of suggestions with strings and other types:
Util.ReadLine ("Choose a name", "Joe", new[] { "Jane", "Jack", "Mary", "David" }).Dump();

// There's also an asynchronous version of this function, Util.ReadLineAsync, which returns a Task<T> instead of T.