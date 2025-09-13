<Query Kind="Statements" />

// LINQPad ships with a command-line version, LPRun8.exe.
//
// You can use this to run LINQPad scripts form the command line.
//
// We'll demonstrate it by creating a simple script and then calling LPRun via Util.Cmd:

string tempQueryPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempQueryPath, "Environment.MachineName.ToUpper()");

// If you're using the xcopy-deploy version, you'll need to call LPRun8-x64.exe or LPRun8-arm64.exe.

string lprunPath = Path.Combine (Util.LINQPadFolder, "LPRun8.exe");
Util.Cmd (lprunPath, $"-lang=expression {tempQueryPath}");

// For a detailed reference on using LPRun, go to https://www.linqpad.net/lprun.aspx
