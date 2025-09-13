// LINQPad Statements

// When you hit the 'Stop' button or press Shift+F5, LINQPad normally cancels your script by killing its process*.
// To avoid this and preserve the process upon cancellation, you can monitor this.ScriptCancelToken.
// Soft cancellation is great if you need to execute cleanup code upon cancellation.

while (true)
{
	// When you monitor ScriptCancelToken, the cancel button changes from red to blue:
	if (ScriptCancelToken.IsCancellationRequested)
	{
		"Nicely ended! We can do cleanup here!".Dump();
		return;
	}
	Thread.Sleep(10);
}

// *If a database query is currently active, LINQPad first cancels the underlying SQL command.