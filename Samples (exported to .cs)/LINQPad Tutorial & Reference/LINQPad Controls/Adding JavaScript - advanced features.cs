// LINQPad Statements

using LINQPad.Controls;

// The follow enables JQuery (you would probably do this at the start of the script):
Util.HtmlHead.AddScriptFromUri ("https://code.jquery.com/jquery-3.4.1.min.js");

var button = new Button ("Test").Dump();
Util.JS.Run ($"$( 'button' ).html( 'Set via JQuery...' )");

// For more advanced features, there is a third-party library called LINQPadPlus that
// further enhances LINQPad's JavaScript interop:
// https://github.com/vlad2048/LINQPadPlus