// LINQPad Statements

using System.Threading.Tasks;

// You can use C#'s await keyword in 'C# Statements' and 'C# Program' mode (and the VB equivalents).
//
// Here's an example in 'C# Statements' mode.

"Starting".Dump();

await Task.Delay (3000);

"Finished".Dump();

// Scripts that use Tasks need to import the 'System.Threading.Tasks' namespace (F4).
// If you've got a Pro/Premium edition, you can use the smart-tag for this. Just type
// Task and then press Alt+Enter / Option-Return to import the required namespace.