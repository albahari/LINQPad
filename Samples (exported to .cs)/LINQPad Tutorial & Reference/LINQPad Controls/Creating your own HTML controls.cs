// LINQPad Statements

using LINQPad.Controls
using System.Threading.Tasks

// You can subclass Control to create your own controls. Here's a really simple example:
new H1 ("testing").Dump();

// The following displays a spinner and then hides it after 3 seconds:
var spinner = new Spinner().Dump();
Task.Delay (3000).ContinueWith (_ => spinner.Visible = false);

// To create a composite control (with children), add the child controls to the VisualTree (protected property).
// For instance, LINQPad's CheckBox is a label that contains an input control and a caption control.
// To see how how it was implemented, click on the CheckBox symbol below and hit F12 to decompile:
new CheckBox ("Option").Dump();

class H1 : Control
{
	public H1 (string text = null) : base ("h1") => Text = text;

	public string Text
	{
		get => HtmlElement.InnerText;
		set => HtmlElement.InnerText = value;
	}
}

class Spinner : Control    // Define this in the "My Extensions" query to be reusable
{
	public Spinner() : base ("div") => HtmlElement.InnerHtml = "<div class='spinner'> </div>";

	protected override void OnRendering (EventArgs e)
	{
		Util.HtmlHead.AddStyles (@".spinner {
  border: 10px solid #eee;
  border-top: 10px solid #39d;
  border-radius: 50%;
  width: 30px;
  height: 30px;
  animation: spin 2s linear infinite;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}");
		base.OnRendering (e);
	}
}