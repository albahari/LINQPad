<Query Kind="Statements">
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

// nint/nuint are native-sized signed/unsigned integral types introduced in C# 9.
// Native-sized means sized to the address space at runtime (either 32 or 64 bits).
//
// Native-sized integers can improve efficiency, overflow safety and convenience when performing
// pointer arithmetic.
//
// The gain in efficiency arises because when you subtract two pointers in C#, the result is always
// a 64-bit integer (long), which is inefficient on 32-bit platforms. By first casting the pointers
// to nint, the result of a subtraction is also nint (which will be 32 bits on a 32-bit platform):

unsafe nint AddressDif (char* x, char* y) => (nint)x - (nint)y;

// The gain in overflow safety and convenience arises when you need a type to represent an offset in
// memory or a buffer length. This is because the historical alternative to using nint/nuint has been
// to repurpose System.IntPtr and System.UIntPtr, types whose intended purpose is to wrap operating
// system handles or address pointers (allowing interop outside an unsafe context). Although being
// natively sized, these types have limited support for arithmetic — and the support they have is always
// unchecked (so overflows fail silently).
//
// In contrast, native-sized integers behave much like standard integers, with full support
// for arithmetic operations and overflow checking:

nint x = 123, y = 234;
(x + y).Dump();
(x * y).Dump();

nuint max = 0;
checked
{
	max--;   // Throws an OverflowException (as it should)
}
