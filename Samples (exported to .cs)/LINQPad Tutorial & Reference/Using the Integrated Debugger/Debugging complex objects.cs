// LINQPad Statements

// Step through the following script and take a look at the local variables in the Locals window.

Uri someUri;
Type someType;

for (int i = 0; i < 10; i++)
{
	someUri = new Uri ("http://test" + i);
	someType = typeof(int).Assembly.ExportedTypes.Skip(i).First();
}

// You can descend to any depth with the TreeView-style control. The columns automatically resize
// as you scroll. You can also Dump any complex object by clicking the 'Dump' hyperlink.
//
// The debugger is fully asynchronous, so you can step/resume while the debug windows are still
// evaluating properties.