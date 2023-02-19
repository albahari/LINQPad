<Query Kind="Program" />

// Local methods can now be declared as static, isolating them from the outer method's variables.

void Main()
{
	int y = 5;
	int x = 7;
	Add (x, y).Dump();

	// The static keyword means we can't access local variables (x and y):
	static int Add (int left, int right) => left + right;
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions