// LINQPad Expression

#r: "nuget: System.Reactive"

using System.Reactive;
using System.Reactive.Linq;

// LINQPad has special support for dumping Reactive Extensions observables.
//
// Try this:

Observable.Interval (TimeSpan.FromMilliseconds (500)).Take(10)

// LINQPad renders IAsyncEnumerable in the same way.