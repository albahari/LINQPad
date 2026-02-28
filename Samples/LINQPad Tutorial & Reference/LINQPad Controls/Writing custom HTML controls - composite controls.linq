<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// To create a composite control (with children), add the child controls to the VisualTree.
	new LabelTextBox ("Name:").Dump();
}

public class LabelTextBox : Control
{
	public readonly Label LabelControl;
	public readonly TextBox TextBoxControl;

	public LabelTextBox (string text = "")
	{
		HtmlElement["class"] = "label-textarea";
		
		VisualTree.Add (LabelControl = new Label (text).WithStyle ("margin-right", "10px"));
		VisualTree.Add (TextBoxControl = new TextBox());
	}

	protected override Control FocusableControl => TextBoxControl;

	public override event EventHandler Click
	{
		add => TextBoxControl.Click += value;
		remove => TextBoxControl.Click -= value;
	}

	// The OnRendering method fires just *before* the control is dumped.
	protected override void OnRendering (EventArgs e)
	{
		// This is the last chance to add stuff the VisualTree, should you need to.
		// After the control is rendered, the VisualTree is fixed.
		
		base.OnRendering (e);
	}
}

// VisualTree is a protected property so consumers can't access it.
// (Alternatively, you can subclass Div and add controls to the public Children property.)