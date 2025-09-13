<Query Kind="Statements">
  <Reference Relative="DemoFile.txt">DemoFile.txt</Reference>
</Query>

/* NON-ASSEMBLY FILES

You can also reference files that are not .DLLs (e.g., text, XML files, JSON files).
LINQPad will then copy these files to the output folder.

You can then access those files with AppContext.BaseDirectory: */

string demoFilePath = Path.Combine (AppContext.BaseDirectory, "DemoFile.txt");
File.ReadAllText (demoFilePath).Dump ("Demo file.txt");

// The LINQPad GUI also lets you take the following shortcut, because it synchronizes
// the current directory with AppContext.BaseDirectory (see preceding script):
File.ReadAllText ("DemoFile.txt").Dump ("Demo file.txt");
