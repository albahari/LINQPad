// LINQPad Statements

using LINQPad.Controls;

var singleThreadedButton = new Button ("I'm singlethreaded", b => "single clicked".Dump()).Dump();
var multiThreadedButton  = new Button ("I'm multithreaded",  b => "multi clicked".Dump()).Dump();

multiThreadedButton.IsMultithreaded = true;

// If the main thread is busy, events will queue up - unless you set IsMultithreaded to true.
Thread.Sleep (5000);

// See script://Demo_-_WaitForButtonPress for a more practical demo.