// LINQPad Statements

// Each LINQPad script runs in its own process.
// LINQPad normally preserves the process between executions (this is how Util.Cache can work).

// Should this ever get in the way, you can tell LINQPad to use a fresh process on next execution:
Util.NewProcess = true;

// or tell LINQPad to kill the current process immediately:
// Environment.Exit(0);

Process.GetCurrentProcess().Id.Dump ("Process ID");

// In Settings > Execution, you can make LINQPad always use a new process per execution.
// You can also ask LINQPad to kill the current process on demand by pressing Ctrl+Shift+F5 / Shift-Command-F5.
