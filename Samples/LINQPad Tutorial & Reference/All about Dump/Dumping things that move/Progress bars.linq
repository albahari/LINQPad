<Query Kind="Statements" />

// You can control LINQPad's main progress bar (shown in the status bar) like this:

for (int i = 0; i < 100; i++)
{
	Util.Progress = i;		
	Thread.Sleep (30);
}

// You can also make custom inline progress bars as follows:

var fast = new Util.ProgressBar ("Fast progress").Dump();
var slow = new Util.ProgressBar ("Slow progress").Dump();

for (int i = 0; i <= 100; i++)
{
	slow.Percent = i;
	fast.Percent = i * 2;
	Thread.Sleep (30);
}

// LINQPad also provides HTML controls that you can dump inline.
// See query://../../LINQPad_Controls