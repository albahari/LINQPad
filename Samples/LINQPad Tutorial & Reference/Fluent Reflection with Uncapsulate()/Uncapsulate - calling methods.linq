<Query Kind="Statements" />

// Calling an object's private methods is easy with Uncapsulate():
var demo = new Demo().Uncapsulate();
demo.PrivateMethod (100).Dump();

// The uncapsulator will perform implicit numeric conversions for you automatically:
demo.PrivateMethod ((byte)100).Dump();

// It will also perform overload resolution:
demo.PrivateMethod ("some string").Dump();

// ...even with ref and out parameters:
demo.PrivateMethod (out string s);
s.Dump();

// Optional parameters are also supported:
demo.OptionalParamMethod (100);

// as are indexers:
demo[123].Dump ("indexer"); 

// You can also call generic methods, as long as you're able to specify type parameters:
demo.GenericMethod<DateTime>();

class Demo
{
	string PrivateMethod (int x) => "Private method! (int) " + x;

	string PrivateMethod (string s) => "Private method! (string) " + s;

	void PrivateMethod (out string x) => x = "Passing by reference works!";
	
	void OptionalParamMethod (int x = 1, int y = 2, int z = 3)
		=> new { x, y, z }.Dump ("Optional params");
		
	string this [int index] => index.ToString();

	void GenericMethod<T>() => typeof (T).FullName.Dump ("Type parameter");
}