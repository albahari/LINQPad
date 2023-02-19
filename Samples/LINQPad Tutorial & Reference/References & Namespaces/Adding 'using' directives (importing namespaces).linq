<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

/* To import extra namespaces ('using' directives), press F4 and click the second tab.
   (Or use the direct shortcut, Ctrl+Shift+M.)
   
   Type in the namespaces you want, or click the 'Pick from assemblies' hyperlink.
   
   You can also remove any of the default namespaces that LINQPad adds.

In this script, we've imported the 'System.Numerics' namespace, so we can use 
the Complex number struct without prefixing it with 'System.Numerics'.   */

var c1 = new Complex (10, 0);
var c2 = new Complex (0, 10);

(c1 * c2).Dump();

// TIP: Hit Ctrl+Shift+C to clone the query (including references & namespace imports).
// TIP: Hit Ctrl+Shift+N to create a new query with the same references & namespaces.
//
// (If you forget these shortcuts, both options are on the File menu.)