// LINQPad Program

// Using declarations let you implicitly dispose an object when the code block exits.

void Main()
{
	WriteLinesToFile ("the quick brown fox".Split());
}

static void WriteLinesToFile (IEnumerable<string> lines)
{
	// Note the using statement without parenthesis or a block.
	// It will dispose when the block (method in this case) exits.	
	using var file = new System.IO.StreamWriter ("WriteLines2.txt");

	foreach (string line in lines)
	{
		// If the line doesn't contain the word 'Second', write the line to the file.
		if (!line.Contains ("Second"))
		{
			file.WriteLine (line);
		}
	}
	
	// file is disposed here
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations