<Query Kind="Statements" />

// You can also now pass a lambda into a method parameter of type object, Delegate or Expression:

M1 (() => "test");
M2 (() => "test");
M3 (() => "test");

void M1 (object x) => x.GetType().Name.Dump();
void M2 (Delegate x) => x.GetType().Name.Dump();
void M3 (Expression x) => x.GetType().Name.Dump();

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/lambda-improvements.md