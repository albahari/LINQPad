// LINQPad Statements

using LINQPad.Controls

// The easiest way to execute JavaScript is to call Util.InvokeScript with 'eval':
Util.InvokeScript (true, "eval", "1+1").Dump ("1 + 1");

Util.InvokeScript (true, "eval", "document.body.innerHTML").Dump ("Document HTML");

Util.InvokeScript (true, "eval", @"
    var headings = document.getElementsByTagName ('h1');

    for (let h of headings)
        h.style.color = 'red';

    headings.length;  // return the number of headings to the caller").Dump ("H1 count");

// You can also add functions to the HTML <head>:
Util.HtmlHead.AddScript ("function foo(x) { alert(x) }");

// and then call them as follows:
Util.InvokeScript (false, "foo", "test");

// The first argument (false) indicates that we don't need the return value. This can
// speed up the call, as it doesn't have to wait for a return value.
//
// Note that you can call Util.HtmlHead.AddScript anytime (not just at the start of the script).

// Let's call our 'foo' function from a button click:
var button = new Button ("Click me").Dump();
button.Click += (sender, args) => button.HtmlElement.InvokeScript (false, "foo", "button clicked");

// button.HtmlElement.InvokeScript is the same as Util.InvokeScript, except that it delays
// execution if the control in question hasn't yet been dumped.