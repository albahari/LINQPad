<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

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

// You can CANNOT add Children *after* the control has been dumped.
// newDiv.Children.Add(...)  // Illegal!

// Also note that Controls can directly contain only **other Controls and DumpContainers**.
// You can't add arbitrary objects such as `customer`:
var customer = new { FirstName = "Mary", LastName = "Woo" };
// new Div (new Span ("Customer"), customer).Dump();  // Illegal!

// Instead, wrap your content in a DumpContainer:
new Div (new Span ("Customer"), new DumpContainer (customer)).Dump();   // Correct

// The DumpContainer approach also makes it easy to swap out content later.
// A DumpContainer can itself contain controls.

// ADVANCED NOTE: when you call Dump on a Span or other inline element, LINQPad wraps
// your element in a div (you can think of Dump as being like Console.WriteLine()).
// To do the equivalent of Console.Write, call DumpInline instead of Dump:
new Span ("in").DumpInline(); new Span ("line").DumpInline();  // Writes "inline"