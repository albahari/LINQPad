<Query Kind="Statements">
  <Output>DataGrids</Output>
  <Namespace>LINQPad.Controls</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// The easiest way to execute JavaScript is to call Util.JS.Eval or Util.JS.Run:
Util.JS.Eval ("1+1").Dump();
Util.JS.Eval ("document.body.innerHTML").Dump();

string script = """
	var headings = document.getElementsByTagName ('h1');
	
	headings[0].style.color = 'red';
	
	headings.length;  // return the number of headings to the caller
	""";

Util.JS.Eval (script).Dump ("H1 count");

// Use Util.JS.Run if your expression has no return value (or if it has one but you don't need it):
Util.JS.Run ("alert ('test')");

// You can also add functions to the HTML <head>:
Util.HtmlHead.AddScript ("function Square(x) { return x * x }");

// and then call them as follows:
Util.JS.EvalFunction ("Square", 3).Dump();

// (You can call Util.HtmlHead.AddScript anytime - not just at the start of the script.)
