<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Rather than awaiting a Task and then dumping the result, you can Dump it directly.
// The call to Dump is non-blocking.

var task1 = Task.Delay (2000).ContinueWith (_ => "Completed!");
var task2 = Task.Delay (2500).ContinueWith (_ => "Completed!");

task1.Dump ("Wait for it...");
task2.Dump ("Wait for it...");

// You can also await in LINQPad - see script://../../Using_Advanced_C#_Features_in_LINQPad