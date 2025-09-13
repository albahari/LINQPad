// LINQPad Statements

#r: "nuget: System.Reactive"

using System.Reactive;
using System.Reactive.Linq;

// Another way to dump streams side-by-side is to use the Util.HorizontalRun method:

var zeroToNine = Observable.Interval (TimeSpan.FromMilliseconds (500)).Take (10);

Util.HorizontalRun (true,

	zeroToNine.Select (x => x * 2),    
	zeroToNine.Select (x => x * 2 + 1)
	
).Dump();
