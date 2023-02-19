<Query Kind="Program" />

// A default interface implementation lets you add a member to an interface
// without breaking existing implementations:

void Main()
{
	ILogger foo = new Logger();
	foo.Log (new Exception ("test"));	
}

class Logger : ILogger
{	
	public void Log (string message) => Console.WriteLine (message);
}

interface ILogger
{
	void Log (string message);	
	
	// Adding a new member to an interface need not break implementors:
	public void Log (Exception ex) => Log (ExceptionHeader + ex.Message);
	
	// The static modifier (and other modifiers) are now allowed:
	static string ExceptionHeader = "Exception: ";
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#default-interface-methods