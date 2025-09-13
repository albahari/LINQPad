<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

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

for (int i = 3; i < 100; i++)
{
	span2.Styles["font-size"] = i + "pt";   // See script://Styling_controls_(css)
	Thread.Sleep (20);
}