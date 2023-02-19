// LINQPad Program

// Generic classes can now derive from System.Attribute:
class GenericAttribute<T> : Attribute { }

// Generic attribute classes must be closed by subclassing before they can be used as an attribute:
class TestAttribute : GenericAttribute<int> { }

[Test]
void Main()
{
}

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/generic-attributes.md
