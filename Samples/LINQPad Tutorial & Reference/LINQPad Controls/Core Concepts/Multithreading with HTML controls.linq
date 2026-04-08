<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// By default, events always run on the main thread, keeping your code *single-threaded*.
// If an event fires while the script is still running, it will queue up until the script has ended.
var singleThreadedButton = new Button ("I'm singlethreaded", b => "single clicked".Dump()).Dump();

// You can change this by setting IsMultithreaded to true.
// Events then fire *right away* on their own thread.
var multiThreadedButton = new Button ("I'm multithreaded",  b => "multi clicked".Dump()).Dump();
multiThreadedButton.IsMultithreaded = true;

// Sleep for 5 seconds. The second button will respond right away during this period.
Thread.Sleep (5000);

// See script://Demo_-_WaitForButtonPress for a more practical demo.
