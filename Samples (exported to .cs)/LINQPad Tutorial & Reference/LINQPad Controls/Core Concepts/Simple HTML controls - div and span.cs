// LINQPad Statements

using LINQPad.Controls;
using System.Threading.Tasks;

// Here's how to create a span, dump it, and then update the content.
var span = new Span ("Construct & dump a span").Dump();
span.Text += "...";

// Div works in the same way:
var div = new Div ("Construct & dump a div").Dump();
div.Text += "...";

// Here's now to specify raw inner HTML instead of Text:
var div2 = Div.FromInnerHtml ("Construct &amp; dump a <b>div</b>").Dump();
div2.HtmlElement.InnerHtml += "...";

// Both span and div let you add child controls:
var span1 = new Span ("This line has ");
var span2 = new Span ("big text");
new Div (span1, span2).Dump();

// Update span2 dynamically:
for (int i = 3; i < 30; i++)
{
	span2.Styles["font-size"] = i + "pt";   // See script://Styling_controls_(css)	
	Thread.Sleep (20);   // await Task.Delay(20) works just as well
}

// You can also add children by calling Children.Add *before* the control is dumped.
var newDiv = new Div();
newDiv.Children.Add (new Button ("test"));
newDiv.Dump();

// NB: You CANNOT add or remove Children *after* the control has been dumped.
// WRONG: newDiv.Children.Add(...)
// WRONG: newDiv.Children.Clear()

// Instead, use a DumpContainer to swap out the whole div:
var dcDiv = new DumpContainer (new Div (new Button ("button 1"))).Dump ();
dcDiv.Content = new Div (new Div (new Button ("button 1"), new Button ("button 2")));

// Also note that Controls can contain only **other Controls and DumpContainers**.
// You can't add arbitrary objects such as `customer`:
var customer = new { FirstName = "Mary", LastName = "Woo" };
// WRONG: new Div (new Span ("Customer"), customer).Dump();

// The solution, again, is to leverage DumpContainer, which can wrap anything:
new Div (new Span ("Customer"), new DumpContainer (customer)).Dump();   // Correct

// ADVANCED NOTE: when you call Dump on a Span or other inline element, LINQPad wraps
// your element in a div (you can think of Dump as being like Console.WriteLine()).
// To do the equivalent of Console.Write, call DumpInline instead of Dump:
new Span ("in").DumpInline(); new Span ("line").DumpInline();  // Writes "inline"