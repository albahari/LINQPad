// LINQPad Statements

#r: "nuget: System.Reactive"

using System.Reactive;
using System.Reactive.Linq;

// The DumpLatest extension method renders just the latest element:

Observable.Interval (TimeSpan.FromSeconds (0.2)).DumpLatest();
Observable.Interval (TimeSpan.FromSeconds (0.3)).DumpLatest();

// The effect is rather like using a DumpContainer - script://../Dumping_things_that_move/DumpContainer