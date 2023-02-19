<Query Kind="Statements">
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

// You can improve performance by applying the unmanaged keyword to the function pointer
// declaration, and the [UnmanagedCallersOnly] attribute to the callback method.

EnumWindows (&PrintWindow, (nuint)0);

[DllImport ("user32.dll")]
static extern int EnumWindows (delegate* unmanaged<nuint, nuint, byte> hWnd, nuint lParam);

[UnmanagedCallersOnly]
static byte PrintWindow (nuint hWnd, nuint lParam)
{
	hWnd.Dump();
	return 1;
}

// The PrintWindow method can then *only* be called from unmanaged code.
// This allows the runtime to take shortcuts.
//
// Note you can use only blittable types in the callback signature when
// using [UnmanagedCallersOnly] - this includes the primitive integral
// types, float and double, and structs that contain blittable types.
