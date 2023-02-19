<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

// To use LINQPad with xunit, select the option on the Query menu: 'Add xunit test support'.
// This adds a '#load "xunit"' directive to your query and imports the Xunit namespace.
//
// You can then call RunTests() to initiate testing.
//
// Note that 'xunit.linq' file is created automatically on first use.
// You can edit this query to customize test behavior as required.

#load "xunit"   // Ctrl+Click on "xunit" to open/edit the xunit query.

void Main()
{
	// Executes the tests and displays the results. Failed tests show at the top.
	RunTests();	
}

#region private::Tests

[Fact] public void Test_ShouldSucceed() => Assert.True (1 + 1 == 2);
[Fact] public void Test_ShouldFail()    => Assert.True (1 + 1 == 3);

// You can also define tests in a (public) class:
public class TestFixture
{
	[Fact] void Test_ShouldSucceed() => Assert.True (1 + 1 == 2);
}

#endregion