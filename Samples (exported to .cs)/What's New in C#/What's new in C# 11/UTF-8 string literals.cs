// LINQPad Statements

// You can specify UTF-8 encoded string literals in C# 11 with the 'u8' suffix:

var utf8  = "abc"u8;   // ReadOnlySpan<byte>

// The compiler expands this to:
var utf8_ = new ReadOnlySpan<byte> (new byte[] { 97, 98, 99 });

utf8.Dump ("UTF-8");

// A UTF-8 string literal has the type ReadOnlySpan<byte>.
// You can convert it to a byte[] with ToArray():
byte[] asArray = utf8.ToArray();

// UTF-8 strings take up less space in memory (because UTF-8 a variable-length encoding).

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/utf8-string-literals.md