// LINQPad Statements

// C# 13 lock statement supports .NET 9's new Lock type:

var locker = new System.Threading.Lock();
lock (locker)
{
	"test1".Dump();
}

// This is equivalent to the following:
using (locker.EnterScope())
{
	"test2".Dump();
}

// .NET 9's Lock type is simpler and faster than Monitor.Enter / Monitor.Exit
// (see https://github.com/dotnet/runtime/issues/34812)

// More info:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/lock-object