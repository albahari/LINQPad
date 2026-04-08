// LINQPad Statements

// The Decompile() extension method decompiles any .NET type to C# source code using ILSpy.
// This works on your own types, BCL types, and types from NuGet packages.

typeof (Uri).Decompile().Dump ("Full decompilation of System.Uri");

// Use signaturesOnly to see just the API surface — no method bodies:

typeof (Uri).Decompile (signaturesOnly: true).Dump ("Uri signatures");

// Include base type members with includeBaseTypes. This walks the inheritance chain
// and produces a separate type declaration for each level (excluding System.Object):

typeof (FileStream).Decompile (signaturesOnly: true, includeBaseTypes: true)
	.Dump ("FileStream with base types");

// By default, only public members are shown. You can include protected and private/internal members as follows:

typeof (List<int>).Decompile (signaturesOnly: true, includeProtectedMembers: true, includePrivateMembers: true).Dump("int with protected and private members");
