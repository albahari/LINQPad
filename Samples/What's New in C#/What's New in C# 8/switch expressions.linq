<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

// An expression-based version of the switch statement is supported from C# 8

void Main()
{
	var color = FromRainbow (Rainbow.Green);
	new Panel { BackColor = color }.Dump();
}

public static Color FromRainbow (Rainbow colorBand) =>   // switch expression
	colorBand switch
	{
		Rainbow.Red => Color.Red,
		Rainbow.Orange => Color.Orange,
		Rainbow.Yellow => Color.Yellow,
		Rainbow.Green => Color.Green,
		Rainbow.Blue => Color.Blue,
		Rainbow.Indigo => Color.Indigo,
		Rainbow.Violet => Color.Violet,
		_ => throw new ArgumentException (message: "invalid enum value", paramName: nameof (colorBand)),
	};
	
public enum Rainbow
{
	Red,
	Orange,
	Yellow,
	Green,
	Blue,
	Indigo,
	Violet
}

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions