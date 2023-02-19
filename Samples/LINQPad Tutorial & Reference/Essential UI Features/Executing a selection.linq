<Query Kind="Program" />

void Main()
{
	// To execute a portion of a query, select the text and hit Run (F5 or Alt+X).
	// Try selecting one of the following lines and hitting F5:
	
	(2 + 2).Dump();
	
	Square (3).Dump();
	
	DateTime.Now.ToString ("dd-MMM-yyyy").Dump ("Custom format string");
	
	// You can also highlight just an *expression*, even if the query is in Statements/Program mode.
	// Highlight just "2 + 2" or "DateTime.Now" and hit F5.
}

int Square (int x) => x * x;
