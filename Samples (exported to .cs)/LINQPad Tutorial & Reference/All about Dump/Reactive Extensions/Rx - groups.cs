// LINQPad Expression

#r: "nuget: System.Reactive"

using System.Reactive
using System.Reactive.Linq

// You can also dump streams inside streams:

Observable.Interval (TimeSpan.FromSeconds (0.5)).Take (20).GroupBy (x => x % 2)