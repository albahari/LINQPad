<Query Kind="Statements">
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

// nint/nuint have always been identical to IntPtr/UIntPtr at runtime, but (used to) exhibit 
// different compile-time behavior (and still do when you target .NET 6 or earlier).

// OLD BEHAVIOR (when you target .NET 6 or earlier)
//
//  - IntPtr/UIntPtr act as they have historically, exposing only members to represent a memory
//    address or offset, with limited and flawed (always-unchecked) arithmetic support.
//
//  - nint/nuint act as "numbery" types, exposing a full range of integral arithmetic
//    operations, and correctly honor checked blocks.

// NEW BEHAVIOR (when you target .NET 7 or later)
//
//   - nint  is a synonym for System.IntPtr;
//     nuint is a synonym for System.UIntPtr
//
//   Which means...
//
//   - nint  has been "merged" with IntPtr   (with their features combined)
//     nuint has been "merged" with UIntPtr  (with their features combined)
//
//   - IntPtr/UIntPtr have been "repaired" and now correctly and fully implement arithmetic 
//     operations (with the repairs changing the behavior of the *compiler*, not the *runtime*).

// This means that arithmetic operators that were formerly available only to nint/nint
// (such as multiplication) also now work with IntPtr/UIntPtr:

#if NET7

IntPtr two = 2, three = 3;
(two * three).Dump();

// Conversely, you can now access all of IntPtr's members via the nint alias:

nint.Size.Dump();

#endif

// The fact that IntPtr and UIntPtr have been "repaired" is a breaking change, as it changes the
// behavior when you add/subtract an Int32 to them. Whereas this operation was formerly ALWAYS
// unchecked, now it honors checked blocks (when targeting .NET 7+).

// To illustrate, the following code throws when you set the .NET version in dropdown above
// to .NET 7, but not when you set it to .NET 6:

IntPtr max = IntPtr.MaxValue;
checked
{
	IntPtr test = max + 1;
}

// Note that this new behavior applies only to code that you recompile under .NET 7.
// The behavior of IntPtr/UIntPtr does not change for old DLLs - and for projects
// that target older frameworks - even if compiled with the C# <LangVersion> forced to 11.
//
// Also, nint/nuint does not break from its C# 9 behavior (it just gains functionality).
