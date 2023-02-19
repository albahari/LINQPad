// LINQPad Program

// From C# 8, you can mark a method in a struct as readonly to indicate that it doesn't mutate fields.

void Main()
{
}

public struct Point
{
	public double X { get; set; }
	public double Y { get; set; }	
	
	// Note the readonly modifier. This will generate a compiler error if you try and modify
	// the struct's fields within the method.	
	public readonly override string ToString() => $"({X}, {Y}) is {Distance} from the origin";

	// We need a readonly modifier here to avoid a warning in the method above.
	public readonly double Distance => Math.Sqrt (X * X + Y * Y);
}

// For more info, see https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#readonly-members