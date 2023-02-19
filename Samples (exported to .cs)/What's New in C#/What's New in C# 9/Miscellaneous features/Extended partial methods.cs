// LINQPad Statements

// C# 9 introduces 'Extended Partial Methods'.
// A partial method is 'extended' if it has an accessiblity modifier (previously illegal).
// Extended partial methods can have a non-void return type and can include 'out' parameters.

new A().Test1().Dump();
new A().Test2(out var s); s.Dump();

partial class A
{
	public partial string Test1();
	
	public partial string Test2 (out string s);
}

partial class A
{
	public partial string Test1() => "Hello, world";
	
	public partial string Test2 (out string s) => s = "Hello, world";
}

// Extended partial methods *must* have implementations: if you comment out either
// of the method implementations in the class above, the code won't compile.
//
// This is not the case with non-extended partial methods, which melt away when
// there's no accompanying definition.