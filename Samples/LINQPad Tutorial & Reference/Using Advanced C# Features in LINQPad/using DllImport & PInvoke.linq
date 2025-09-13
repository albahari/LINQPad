<Query Kind="Program">
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

// You can use DllImport to call unmanaged functions (P/Invoke).
// This is great for testing.

void Main()
{
#if UNIX
	Console.WriteLine ($"User ID: {getuid()}");
#else
	IsUserAnAdmin().Dump ("We have administrative elevation");
#endif	
}

[DllImport ("shell32.dll", EntryPoint = "#680")]
public static extern bool IsUserAnAdmin ();

[DllImport ("libc")]
static extern uint getuid();
