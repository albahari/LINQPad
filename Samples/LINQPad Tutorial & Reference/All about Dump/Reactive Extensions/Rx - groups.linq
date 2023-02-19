<Query Kind="Expression">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

// You can also dump streams inside streams:

Observable.Interval (TimeSpan.FromSeconds (0.5)).Take (20).GroupBy (x => x % 2)