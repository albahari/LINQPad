// LINQPad Statements

using LINQPad.Controls;
using System.Threading.Tasks;

// You can also dump simple <div> or <span> elements and dynamically set their content:

var div = new Div().Dump();

for (int i = 3; i < 100; i++)
{
	div.HtmlElement.InnerHtml = $"This line has <span style='font-size:{i}pt'>big text</span>";	
	// await Task.Delay(20) will work just as well:
	Thread.Sleep (20);        
}

// Here's another way to accomplish the same thing:

var span1 = new Span ("This line has ");
var span2 = new Span ("big text");

new Div (span1, span2).Dump();

// span1 and span2 become the Children of the Div. You can also do it like this:

var div2 = new Div();
div2.Children.Add (new Span ("Test"));
div2.Dump();

// Note that you can CANNOT add Children after the control has been dumped.

for (int i = 3; i < 100; i++)
{
	span2.Styles["font-size"] = i + "pt";   // See script://Styling_controls_(css)
	Thread.Sleep (20);
}