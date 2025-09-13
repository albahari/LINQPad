// LINQPad Program

// In C# 9, you can nominate a static method as a 'Module initializer' via the ModuleInitializer attribute.
// This method runs automatically when the containing assembly is first loaded.
//
// NB: This feature requires .NET 5+. It will not compile in .NET 3.1.

void Main()
{
	"Test".Dump();
}

// In this demo, the Init() method will run once, before the Main method prints "Test".
// If you re-run the script, it won't run again because the assembly will already be loaded.

[System.Runtime.CompilerServices.ModuleInitializer]
internal static void Init()
{
	$"Module initializer for script {Assembly.GetExecutingAssembly().GetName()}".Dump(); 	
}
