// LINQPad Program

#nullable enable

// Whereas nullable value types bring nullability to value types, nullable reference types
// do the opposite. When enabled, they bring (a degree of) non-nullability to reference types,
// with the purpose of helping to avoid NullReferenceExceptions.
//
// Nullable reference types introduce a level of safety that’s enforced purely by the compiler,
// in the form of warnings when it detects code that’s at risk of generating a NullReferenceException.
//
// The following directive enables nullable reference types (in LINQPad, you can also set a global
// default in Settings).


void Main()
{
}

class Person
{	
	public string FirstName;   // Not null
	public string? MiddleName; // May be null
	public string LastName;    // Not null
}

void M1 (Person p)
{
	p.MiddleName.Length.Dump();  // WARNING: may be null
	p.MiddleName!.Length.Dump(); // ok, you know best!
}

void M2 (Person p)
{
	p.FirstName = null;           // 1 WARNING: it's null
	p.LastName = p.MiddleName;    // 2 WARNING: may be null
	string s = default (string);  // 3 WARNING: it's null
	string[] a = new string [10]; // 4 ok: too common
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#nullable-reference-types