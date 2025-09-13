// LINQPad Program

// LINQPad lets you write special "hook" methods that are called at various stages of script execution.
// These can be particularly useful in scripts that you #load - see https://www.linqpad.net/LinqReference.aspx

void Main()
{	
	"Main method".Dump();
}

void OnInit()   // Executes once when the process initializes (like a static constructor)
{
	// This will print the first time you run the script
	// (and again, if you kill the process with Ctrl+Shift+F5 / Shift-Command-F5).
	"Script process initializing".Dump();
}

void OnStart()  // Executes just before the script is started
{
	"Script starting".Dump();
}

void OnFinish()  // Executes after the main thread finishes executing the script code.
{
	"Script finished".Dump();
}

void Hijack()    // Runs instead of the Main method
{
	// Note that there can be only one Hijack method in (current script + all scripts that you #load).
	"Hijack - start".Dump();
	Main();
	"Hijack - end".Dump();
}
