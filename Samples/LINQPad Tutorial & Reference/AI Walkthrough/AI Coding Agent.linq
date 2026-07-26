<Query Kind="Program">
  <Namespace>System.Net</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

/* LINQPad's coding agent works from directly within the editor.

With all providers except Claude Code, it manually orchestrates to
maximize token efficiency. (With Claude Code, it uses Claude's agentic loop.)

With the coding agent, you can:
	- ask questions about the current script
	- write new scripts
	- edit/refactor existing code with red/green diffing
	- demo C# and .NET features
	- demo LINQPad features such as Dump(), Chart() and Excel interop
	- get started with any popular NuGet package

LINQPad checks the model's output against the compiler, giving the model a 
chance to fix any compilation errors before posting.

To activate, just press Ctrl+I / Command-I.

For instance, press Ctrl+I now and ask it this:

	Modernize this code

The model will replace the obsolete types, use newer C# features and solve the
problem of the hard-coded password. */

void Main()
{
	GetResponse ("hardCodedPassword").Dump();
}

string GetResponse (string password)
{
	using (var client = new WebClient())
	{
		client.Headers.Add ("Auth", password);
		return client.DownloadString ("http://example.com/");
	}
}

// TIP: Anthropic's *Sonnet* and *Opus* are terrific models to use with the coding agent.
//      Both are available through OpenRouter, Anthropic or via Claude Code.
//
// TIP: To focus the model's attention on a particular piece of code, 
//      select that code in the editor before submitting.
//
// TIP: The Undo/Redo buffer works with diffs.
//
// TIP: If you're using Copilot or Claude Code, you can get similar results
//      by going directly to Chat.