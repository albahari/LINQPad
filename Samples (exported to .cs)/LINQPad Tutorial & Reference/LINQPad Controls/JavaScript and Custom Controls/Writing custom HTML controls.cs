// LINQPad Program

using LINQPad.Controls;
using System.Threading.Tasks;

// You can subclass Control to create your own controls.
// This simplifies design and allows for re-use.

void Main()
{
	// Here's a really simple example:
	new H1 ("testing").Dump();
	
	// The following displays a spinner and then hides it after 3 seconds:
	var spinner = new Spinner().Dump();
	Task.Delay (3000).ContinueWith (_ => spinner.Visible = false);
}

class H1 : Control
{
	public H1 (string text = null) : base ("h1") => Text = text;

	public string Text
	{
		get => HtmlElement.InnerText;
		set => HtmlElement.InnerText = value;
	}
}

// Define this in the "My Extensions" script to be reusable (or save it to a script and #load it)
class Spinner : Control
{
	public Spinner() : base ("div") => HtmlElement.InnerHtml = "<div class='spinner'> </div>";
	
	// The OnRendering method fires just *before* the control is dumped.
	// This is where you should load assets such as styles, css or script libraries.
	protected override void OnRendering (EventArgs e)
	{
		// Util.HtmlHead.AddStyles is idempotent, so it's safe to call it multiple times.
		Util.HtmlHead.AddStyles ("""
			.spinner {
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
			}
			""");
			
		base.OnRendering (e);
	}
}