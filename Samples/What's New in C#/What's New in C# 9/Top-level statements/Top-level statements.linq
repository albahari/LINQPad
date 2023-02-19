<Query Kind="Statements" />

/* Before C# 9, a simple "Hello, world" in Visual Studio required the following volume of code:

class Program
{
  static void Main()
  {
    System.Console.WriteLine ("Hello, world");
  }
}

With C# 9, we can finally cut the clutter! A program can now comprise purely of top-level statements:  */

System.Console.WriteLine ("Hello, world");

// (Of course, you've always been able to take this shortcut in LINQPad.
//  However, top-level statements have a few more features, some of which are also useful in LINQPad.)