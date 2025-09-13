// LINQPad Statements

// On Windows, LINQPad ships with a command-line version, LPRun.
//
// You can use this to run LINQPad scripts form the command line.
//
// We'll demonstrate it by creating a simple script and then calling LPRun via Util.Cmd:

string tempQueryPath = Path.Combine (AppContext.BaseDirectory, "test.linq");
File.WriteAllText (tempQueryPath, "Environment.MachineName.ToUpper()");

// If you're using the xcopy-deploy version, you'll need to call LPRun9-x64.exe or LPRun9-arm64.exe.

string lprunName = $"LPRun{Util.LINQPadVersion.Major}.exe";
string lprunPath = Path.Combine (Util.LINQPadFolder, lprunName);
Util.Cmd (lprunPath, $"-lang=expression {tempQueryPath}");

// For a detailed reference on using LPRun, go to https://www.linqpad.net/lprun.aspx
