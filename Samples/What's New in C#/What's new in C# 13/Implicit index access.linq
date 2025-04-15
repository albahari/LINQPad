<Query Kind="Statements">
  <AutoDumpHeading>true</AutoDumpHeading>
  <RuntimeVersion>9.0</RuntimeVersion>
</Query>

// You can now use the ^ operator in collection initializers:

var reverse = new List<int>(Enumerable.Range (0, 4))
{
	[^1] = 0,
	[^2] = 1,
	[^3] = 2,
	[^4] = 3,
};
	
reverse.Dump();	