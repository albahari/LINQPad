<Query Kind="Statements" />

// Each LINQPad query runs in its own process.
// LINQPad normally preserves the process between executions (this is how Util.Cache can work).

// Should this ever get in the way, you can tell LINQPad to use a fresh process on next execution:
Util.NewProcess = true;

// or tell LINQPad to kill the current process immediately:
// Environment.Exit(0);

Process.GetCurrentProcess().Id.Dump ("Process ID");

// In Edit | Preferences > Advanced, you can make this the default.
// You can also ask LINQPad to kill the current process on demand by pressing Ctrl+Shift+F5.
