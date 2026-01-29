<Query Kind="Statements">
  <Namespace>System.Net</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

/* Having unit tests makes it easy to feed incorrect behavior back to the model.

You can ask the model to write unit tests easily, via a toggle switch in the coding agent.

Demo: press Ctrl+I / Command-I and enable the "Write Unit Tests" toggle switch.

Ask it this:

	Write a method to convert a number into words

Then introduce a bug and run the tests. A highlighted link will appear at the bottom of
the test results to feed the failed tests back to the model.

Click this link, and the model will automatically detect and fix the bug.

For more info on unit testing in LINQPad:
script://../xunit_testing_with_LINQPad  */