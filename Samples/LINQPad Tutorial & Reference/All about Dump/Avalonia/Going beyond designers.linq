<Query Kind="Statements" />

// You can use LINQPad as a replacement for the Avalonia / WPF designer in Visual Studio.
//
// First, add the following assembly attribute to your project in Visual studio:
// [assembly: InternalsVisibleTo ("LINQPadQuery")]
// This will allow LINQPad to access internal types and members in your project.
//
// Now in LINQPad, add a reference to your project's output DLL, and run something like this:

new MyWindow().Content.Dump();    // Render in LINQPad's output panel

// or:

new MyWindow().Show();            // Render in separate window

// This displays your UI in LINQPad without starting the application.

// Advanced tip #1: In many cases, it works to also add a directive such as the following to 
// the top of the query:
//
// #load "c:\source\MyApplication\MyCustomUI.cs"
//
// When you run the query, the code in the #load-ed file takes precedence over what's
// in the referenced DLL. This means you can see the effect of changes to the file,
// without needing to rebuild the DLL in Visual Studio.

// Advanced tip #2: With additional setup in your LINQPad script, you can feed a variety
// of data sources into your UI, to improve testing and help reproduce problems.
