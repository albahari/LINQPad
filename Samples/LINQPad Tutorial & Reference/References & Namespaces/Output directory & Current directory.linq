<Query Kind="Statements" />

// LINQPad runs your scripts in a temporary output folder which you can access with
// AppContext.BaseDirectory or Environment.CurrentDirectory.

AppContext.BaseDirectory.Dump ("Output folder");

// To avoid unnecessary file I/O, LINQPad doesn't copy referenced assemblies into this folder
// unless you tell it to by ticking a checkbox in Script Properties (F4) > Advanced. Doing so can be
// useful when working with dependency injection frameworks that enumerate files in the output folder.

// You can create temporary files in the output folder, and they'll be deleted when the script closes.
File.WriteAllText ("test.txt", "some content");
Util.Cmd (@"dir");

// Notice that we didn't specify a full file path - this works because the LINQPad GUI sets the
// current directory (Environment.CurrentDirectory) to the output directory*.

// Here's a convenient shortcut for opening the current directory in Windows Explorer:
Util.Cmd (@"explorer .");

// You can even open Explorer inside LINQPad, with the following code:
// Util.DisplayWebPage (new Uri (Environment.CurrentDirectory));

// *The command-line version of LINQPad (LPRun.exe), leaves Environment.CurrentDirectory in its ambient state.
