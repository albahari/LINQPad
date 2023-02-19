// LINQPad Statements

// With DumpContainer, you dump a container whose content you can replace whenever you like:

var dc = new DumpContainer ("Optional initial value").Dump();

Thread.Sleep (2000);

for (int i = 0; i < 100; i++)
{
	dc.Content = i;
	Thread.Sleep (200);
}

// Call .ClearContent() to hide a DumpContainer.