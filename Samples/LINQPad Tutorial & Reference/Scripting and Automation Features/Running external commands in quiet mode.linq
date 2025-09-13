<Query Kind="Statements" />

// You can tell LINQPad not to automatically dump the output by calling it with the quiet argument true:

var output = 
	OperatingSystem.IsWindows()
		? Util.Cmd ("dir", "/od", true)
		: Util.Zsh ("ls -l ~", true);
	
// You then access the output (IEnumerable<string>) by dumping the result:
output.Dump();
