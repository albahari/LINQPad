// LINQPad Program

// This is a C# 14 preview feature. To work, you must enable C# Preview features in Settings > Scripts.
//
// In C# 14, there's a new, more flexible, syntax for defining extensions.
// This new syntax permits extension properties and static member extensions.

void Main()
{
	DateTime.Now.ToYmd().Dump();     // Extension method using new syntax
	DateTime.Now.DateOnly.Dump();    // Extension property
	
	DateTime.FromUnixTimestamp (1234556789).Dump();    // Static extension method	
	DateTime.Tomorrow.Dump();                          // Static extension property
	
	Enumerable.Range (0, 100).Count.Dump();     // Extension property on generic type
}

public static class Extensions
{
	// Extension members for DateTime:
	extension (DateTime dt)
	{
		// Extension method:
		public string ToYmd() => dt.ToString ("yyyy-MM-dd");

		// Extension properties:
		public DateOnly DateOnly => DateOnly.FromDateTime (dt);
		public TimeOnly TimeOnly => TimeOnly.FromDateTime (dt);		
	}

	// Static member extensions for DateTime
	extension (DateTime)
	{
		// Static method extension:
		public static DateTime FromUnixTimestamp (long timeStamp)
			=> new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds (timeStamp);

		// Static property extension:
		public static DateTime Tomorrow => DateTime.Now.AddDays (1);
	}

	// Extensions methods on generic type:
	extension<TSource> (IEnumerable<TSource> source)
	{
		// Extension property:
		public int Count => source.Count();
	}
}
