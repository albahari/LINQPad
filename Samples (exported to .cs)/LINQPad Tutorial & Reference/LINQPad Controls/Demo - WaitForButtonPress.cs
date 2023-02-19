// LINQPad Program

using LINQPad.Controls
using System.Threading.Tasks

// The WaitForButtonPress method displays a button and waits for the user to click it.
// You can add this method to the "My Extensions" query and use it as an alternative to Util.ReadLine().
// An async version is also provided.

void Main()
{
	var txt = new TextBox().Dump();
	txt.Focus();
	WaitForButtonPress();
	txt.Text.Dump();	
}

void WaitForButtonPress (string text = "Continue") => WaitForButtonPressAsync (text).Wait();

Task WaitForButtonPressAsync (string text = "Continue")
{
	var finished = new TaskCompletionSource<object>();
	var button = new Button (text, btn =>
	{
		btn.Visible = false;
		finished.TrySetResult (null);
	})
	{
		IsMultithreaded = true    // Allows button to receive events while query is executing.
	}.Dump();
	return finished.Task;
}