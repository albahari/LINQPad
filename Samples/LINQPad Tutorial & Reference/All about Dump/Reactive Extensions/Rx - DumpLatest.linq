<Query Kind="Statements">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

// The DumpLatest extension method renders just the latest element:

Observable.Interval (TimeSpan.FromSeconds (0.2)).DumpLatest();
Observable.Interval (TimeSpan.FromSeconds (0.3)).DumpLatest();

// The effect is rather like using a DumpContainer - query://../Dumping_things_that_move/DumpContainer