// LINQPad Statements

// Util.Try executes code within a try/catch block.
// If the code throws an exception, it (optionally) dumps the exception:

int x = 1;
int y = 0;
Util.Try (() => (x / y).Dump(), true);    // true tells it to dump any exception.
"Execution continues".Dump();

// You can also specify a value to return if an exception is thrown:
var zeroIfError = Util.Try (() => x / y, 0);
zeroIfError.DumpTell();