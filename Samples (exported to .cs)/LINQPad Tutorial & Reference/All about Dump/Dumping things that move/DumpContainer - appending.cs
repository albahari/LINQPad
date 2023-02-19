// LINQPad Statements

// You can append content to a DumpContainer by calling .AppendConent()

"---start---".Dump();
var dc = new DumpContainer().Dump ("List");
"---end---".Dump();

for (int i = 0; i < 10; i++)
{
	dc.AppendContent (i);
	Thread.Sleep(200);
}



