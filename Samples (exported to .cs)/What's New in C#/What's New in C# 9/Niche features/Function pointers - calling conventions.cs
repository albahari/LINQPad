// LINQPad Statements

using System.Runtime.CompilerServices
using System.Runtime.InteropServices

EnumWindows (&PrintWindow, (nuint)0);

[DllImport ("user32.dll")]

// By default, C# assumes that the callback follows the platform-default calling convention.
// You can override this by specifying a calling convention after the unmanaged keyword:
static extern int EnumWindows (delegate* unmanaged[Stdcall] <nuint, nuint, byte> hWnd, nuint lParam);

// and also in the UnmanagedCallersOnly attribute:
[UnmanagedCallersOnly (CallConvs = new[] { typeof (CallConvStdcall) })]
static byte PrintWindow (nuint hWnd, nuint lParam)
{
	hWnd.Dump();
	return 1;
}
