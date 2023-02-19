// LINQPad Statements

using System.Threading.Tasks
using System.Threading.Tasks.Dataflow

// LINQPad has built-in support for Microsoft Dataflow blocks.
//
// You get a live visualization of what's happening when you dump them:

var tb = new TransformBlock<int, int> (async i => 
{
	await Task.Delay (1000);
	return i * 10;
});

var ab = new ActionBlock<int> (async i => 
{
	await Task.Delay (1000);
	Console.WriteLine (i);
});

tb.LinkTo (ab);

for (int i = 0; i < 10; i++)
	tb.Post (i);

tb.Dump();
ab.Dump();