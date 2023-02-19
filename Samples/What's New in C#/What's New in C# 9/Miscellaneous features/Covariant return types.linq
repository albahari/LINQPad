<Query Kind="Statements">
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

// In C# 9, you can now return a more specific type when overriding a method.
//
// NB: This feature requires .NET 5+. It will not compile in .NET 3.1.

new B().Clone().Dump();

class A
{
	public virtual A Clone() => new A();
}

class B : A
{
	public override B Clone() => new B();
}