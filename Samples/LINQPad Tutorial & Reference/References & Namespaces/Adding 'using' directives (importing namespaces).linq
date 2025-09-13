<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

/* To import extra namespaces ('using' directives), go to Script Properties (or press Ctrl+Shift+M / Shift-Command-M.)
   
LINQPad also lets you write normal 'using' directives to the top of a script if you prefer.
   
In this script, we've imported the 'System.Numerics' namespace, so we can use 
the Complex number struct without prefixing it with 'System.Numerics'.   */

var c1 = new Complex (10, 0);
var c2 = new Complex (0, 10);

(c1 * c2).Dump();

// TIP: Hit Ctrl+Shift+C / Shift-Command-C to clone the script (including references & namespace imports).
// TIP: Hit Ctrl+Shift+N / Shift-Command-N to create a new script with the same references & namespaces.
//
// (If you forget these shortcuts, both options are on the File menu.)

