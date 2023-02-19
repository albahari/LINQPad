<Query Kind="Statements">
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

// Here's how to use a function pointer to call an unmanaged method:

EnumWindows (&PrintWindow, (nuint)0);

[DllImport ("user32.dll")]
static extern int EnumWindows (delegate*<nuint, nuint, bool> hWnd, nuint lParam);

static bool PrintWindow (nuint hWnd, nuint lParam)
{
	hWnd.Dump();
	return true;
}