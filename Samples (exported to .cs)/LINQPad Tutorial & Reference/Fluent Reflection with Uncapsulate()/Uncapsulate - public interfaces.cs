// LINQPad Statements

// Uncapsulate() is useful even with public interfaces, as an alternative
// to C#'s dynamic language binding. This is because the latter does not
// let you call explicitly implemented members:

ISomeInterface iSomeInterface = new Demo();

dynamic foo = iSomeInterface;

try                  { foo.Test();               }
catch (Exception ex) { ex.Dump ("Not allowed!"); }

// The same thing works nicely with Uncapsulate:
iSomeInterface.Uncapsulate().Test();

// In such scenarios, you can tell Uncapsulate to bind only to public members (a kind of "safe mode"):
iSomeInterface.Uncapsulate (publicMembersOnly:true).Test();

public interface ISomeInterface
{
	void Test();
}

public class Demo : ISomeInterface
{
	void ISomeInterface.Test() => "Explicitly implemented interface method".Dump();
}