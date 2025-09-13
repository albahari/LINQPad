// LINQPad Statements

#r: "nuget: System.Reactive"

using System.Reactive;
using System.Reactive.Linq;

// You can dump multiple streams simultaneously:

var zeroToNine = Observable.Interval (TimeSpan.FromMilliseconds (500)).Take (10);

zeroToNine.Select (x => x * 2)    .Dump ("Evens");
zeroToNine.Select (x => x * 2 + 1).Dump ("Odds");

// TIP: If you click the 'Results to DataGrids' toolbar button above, LINQPad will use WPF
// to render the streams instead of HTML. The WPF renderer displays streams side-by-side.