<Query Kind="Statements" />

// Here's a more detailed example of the dynamic magic that Uncapsulate brings to interfaces:

ITest interfaceTest = new Test();

// This expression runs perfectly with normal static typing...
interfaceTest.Another.Another.Another.Victory();

// ...but fails with C#'s dynamic typing:
dynamic dynamicTest = interfaceTest;
try
{
	dynamicTest.Another.Another.Another.Victory();	
}
catch (Exception ex) 
{
	ex.Dump ("C#'s dynamic failed");
}

// But works with Uncapsulator!
var uncapsulatorTest = interfaceTest.Uncapsulate (publicMembersOnly:true);
uncapsulatorTest.Another.Another.Another.Victory();

class Test : ITest   // All members are explicitly implemented
{
	ITest ITest.Another => new Test();
	void ITest.Victory() => "Success".Dump();
}

interface ITest
{
	ITest Another { get; }
	void Victory();
}