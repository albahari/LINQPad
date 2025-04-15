<Query Kind="Program" />

string greeting = "Hello, world";

void Main()
{
	// To execute a portion of a query, select the text and hit Run (F5 or Alt+X).
	// Try selecting one (or all) of the following lines and hitting F5:

	(2 + 2).Dump();
	greeting.Dump();     // The field initializer still executes
	Square (3).Dump();	
	DateTime.Now.ToString ("dd-MMM-yyyy").Dump ("Custom format string");
	
	// You can also highlight just an *expression*, even if the query is in Statements/Program mode.
	// Highlight just "2 + 2" or "DateTime.Now" and hit F5.
}

int Square (int x) => x * x;

// You can also run an individual method by highlighting the whole method and pressing F5
void Test() => "Test".Dump();

// This also works for methods that have parameters
void Test2 (int x = 123) => x.Dump();

// It even works if the parameters don't have default values!
void Test3 (int x) => x.Dump();

// Note that the ability to highlight and execute a method works only in 'C# Program' mode.