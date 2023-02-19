// LINQPad Statements

#define FOO

// You can #define your own preprocessor symbols, as well as using the predefined ones:



#if FOO
	"Foo".Dump();
#else
	"Bar".Dump();
#endif


// The following are predefined by LINQPad:

#if CMD                          // true if the query is running from the command-line (LPRun.exe)
	"Command-line".Dump();
#endif

#if NETCORE                      // true if running .NET Core 3 or later (i.e., LINQPad 6+ rather than LINQPad 5)
	".NET Core".Dump();
#else
	".NET Framework".Dump();     // must be running in LINQPad 5
#endif

#if NET5
	"You're on .NET 5 or later".Dump();
#endif

#if NET6
	"You're on .NET 6 or later".Dump();
#endif

#if LINQPAD
	"LINQPad".Dump();            // True if running on LINQPad
#endif