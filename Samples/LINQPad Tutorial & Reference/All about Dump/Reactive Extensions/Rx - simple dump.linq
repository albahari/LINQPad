<Query Kind="Expression">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

// LINQPad has special support for dumping Reactive Extensions observables.
//
// Try this:

Observable.Interval (TimeSpan.FromMilliseconds (500)).Take(10)

// LINQPad renders IAsyncEnumerable in the same way.