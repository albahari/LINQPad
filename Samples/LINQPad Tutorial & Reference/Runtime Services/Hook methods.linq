<Query Kind="Program" />

// LINQPad lets you write special "hook" methods that are called at various stages of query execution.
// These can be particularly useful in queries that you #load - see https://www.linqpad.net/LinqReference.aspx

void Main()
{	
	"Main method".Dump();
}

void OnInit()   // Eexecutes once when the process initializes (like a static constructor)
{
	// This will print the first time you run the query (and again, if you kill the process with Ctrl+Shift+F5).
	"Query process initializing".Dump();
}

void OnStart()  // Executes just before the query is started
{
	"Query starting".Dump();
}

void OnFinish()  // Executes after the main thread finishes executing the query code.
{
	"Query finished".Dump();
}

void Hijack()    // Runs instead of the Main method
{
	// Note that there can be only one Hijack method in (current query + all queries that you #load).
	"Hijack - start".Dump();
	Main();
	"Hijack - end".Dump();
}
