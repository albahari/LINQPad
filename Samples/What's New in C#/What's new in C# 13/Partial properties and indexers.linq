<Query Kind="Statements">
  <RuntimeVersion>9.0</RuntimeVersion>
</Query>

// Properties and indexers can now be declared as partial:

new Test().ToString().Dump();

partial class Test    // In auto-generated file
{
	public override string ToString() => Description;

	partial string Description { get; }
}

partial class Test    // In hand-authored file
{
	partial string Description => "Test";
}