<Query Kind="Statements">
  <NuGetReference>Microsoft.CodeAnalysis.CSharp</NuGetReference>
  <Namespace>Microsoft.CodeAnalysis.CSharp</Namespace>
</Query>

// If you're working with Roslyn assemblies (Microsoft.CodeAnalysis), you can visualize syntax trees
// by calling .DumpSyntaxTree()

CSharpSyntaxTree.ParseText (@"class Program
{
	static void Main()
	{
		System.Console.WriteLine (""Hello, world"");
	}
}").DumpSyntaxTree();

// This is the same visualizer that LINQPad uses to visualize your code when you click the 'Tree' button below.