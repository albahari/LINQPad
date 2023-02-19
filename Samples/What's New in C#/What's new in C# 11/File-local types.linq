<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

// Type declarations can include the new 'file' modifier to make the type visible only within the same file.

file class Foo
{
	// This class can be seen only within this file.
}

// In LINQPad, this feature can be useful in scripts that you #load, to create classes that are private to the script.

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/file-local-types.md

void Main() { }