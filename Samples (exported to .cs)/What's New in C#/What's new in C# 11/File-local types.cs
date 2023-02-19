// LINQPad Program

using System.ComponentModel
using System.Runtime.CompilerServices

// Type declarations can include the new 'file' modifier to make the type visible only within the same file.

file class Foo
{
	// This class can be seen only within this file.
}

// In LINQPad, this feature can be useful in scripts that you #load, to create classes that are private to the script.

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/file-local-types.md

void Main() { }