<Query Kind="Program">
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// LINQPad 9+ supports .NET's inbuilt source generators.
//
// These source generators write optimized code at compile-time for:
//   - regular expressions
//   - native library imports
//   - JSON serialization

void Main()
{
	// Match using compile-time generated Regex
	WordCountRegex().Matches ("The quick brown fox jumps over the lazy dog").Count.Dump();
	
	// Call a native method
	GetCurrentThreadId().Dump();
	
	// Serialize using compile-time generated JSON serializer
	var person = new Person ("Alice", 30);
	JsonSerializer.Serialize (person, AppJsonContext.Default.Person).Dump ("JSON");
}

// Regex Source Generator - generates optimized regex code
[GeneratedRegex(@"\b(\w|[-'])+\b")]
private static partial Regex WordCountRegex();

public static int GetCurrentThreadId ()
{
	if (OperatingSystem.IsWindows())
		return GetThreadIdWindows ();
	else
	{
		GetThreadIdMacOS (default, out var result);
		return (int)result;
	}
}

// Library Import Source Generator (note that we use LibraryImport rather than DllImport)
[LibraryImport ("kernel32.dll", EntryPoint = "GetCurrentThreadId")]
private static partial int GetThreadIdWindows();

[LibraryImport ("libc", EntryPoint = "pthread_threadid_np")]
private static partial int GetThreadIdMacOS (IntPtr thread, out ulong threadId);

// JSON Source Generator - generates optimized serialization code
[JsonSerializable (typeof (Person))]
partial class AppJsonContext : JsonSerializerContext { }

record Person (string Name, int Age);