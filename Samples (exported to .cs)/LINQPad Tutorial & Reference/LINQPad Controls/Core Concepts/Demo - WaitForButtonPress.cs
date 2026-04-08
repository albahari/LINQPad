// LINQPad Program

using LINQPad.Controls;
using System.Threading.Tasks;

// The WaitForButtonPress method displays a button and waits for the user to click it.
// You can add this method to the "My Extensions" script and use it as an alternative to Util.ReadLine().
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
	var finished = new TaskCompletionSource();
	var button = new Button (text, btn =>
	{
		btn.Visible = false;
		finished.TrySetResult();
	});
	
	// Allow button to receive events while the script is executing (and the main thread is blocked).
	// Without this line, the script will deadlock!
	button.IsMultithreaded = true;
	
	button.Dump();
	
	return finished.Task;
}