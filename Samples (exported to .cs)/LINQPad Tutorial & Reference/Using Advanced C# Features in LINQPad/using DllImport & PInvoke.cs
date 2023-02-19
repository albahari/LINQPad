// LINQPad Program

using System.Runtime.InteropServices

// You can use DllImport to call unmanaged functions (P/Invoke).
// This is great for testing.

void Main()
{
	IsUserAnAdmin().Dump ("We have administrative elevation");
}

[DllImport ("shell32.dll", EntryPoint = "#680")]
public static extern bool IsUserAnAdmin ();
