<Query Kind="Statements" />

// LINQPad ships with a command-line version, LPRun7.exe.
//
// You can use this to run LINQPad scripts form the command line.
//
// We'll demonstrate it by creating a simple script and then calling LPRun via Util.Cmd:

string tempQueryPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempQueryPath, "Environment.MachineName.ToUpper()");

string lprunPath = Path.Combine (Util.LINQPadFolder, "LPRun7.exe");
Util.Cmd (lprunPath, $"-lang=expression {tempQueryPath}");

// For a detailed reference on using LPRun, go to https://www.linqpad.net/lprun.aspx
//
// TIP: You can improve performance by running NGen on the Roslyn assemblies. Go to the
// LINQPad folder and look at "LPRun readme.txt" for instructions.