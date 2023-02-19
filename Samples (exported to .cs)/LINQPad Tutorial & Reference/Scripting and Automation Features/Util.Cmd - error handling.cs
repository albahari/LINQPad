// LINQPad Statements

// Unlike with batch files, you don't need to check %errorlevel% after each command!
// If a command errors, LINQPad throws an CommandExecutionException:

Util.Cmd (@"dir", "/badflag");    // This will throw

// which means the following line won't execute (unless you exception-handle the above):

Util.Cmd (@"dir");
