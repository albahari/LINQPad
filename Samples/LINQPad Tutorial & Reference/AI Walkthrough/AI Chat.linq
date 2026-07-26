<Query Kind="Statements">
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

/* To activate LINQPad's AI Chat:
	- Press Ctrl+P / Command-P for a new chat
	- Press Alt+I / Command-I to return to an existing chat.

If you're using Copilot, you can choose between fully agentic or manual modes.
**Agentic mode gives the best results for coding tasks**

If you're NOT using Copilot, only the token-efficient manual mode is available.
For best results with coding tasks:
	- Type your instruction instead into inline coding agent (Ctrl+I / Command-I)
	- Click 'Continue conversation' if you need to follow up with chat.
This primes the chat window with everything gained from the initial agentic
interaction while maintaining token efficiency.

With Claude Code, the AI Chat window is redundant (and unavailable):
instead, go directly to the Claude Code window.

In manual mode, the chat tool does not send additional information to
the model. Everything that's sent and received is visible in the chat.

For this reason, you can use this a prompt engineering tool or a general AI
chat tool, with the ability to control the system prompt and rewrite any part
of the conversation each time you submit. With an empty system prompt, the 
model has no idea that it's in LINQPad.

The chat tool has a number of editor integration features that work in manual mode.
The first is the "Enable refactoring" toggle in the top-right. When enabled,
this updates the system prompt with instructions to generate a unified diff in 
response to code editing requests. When LINQPad sees a diff in the output, it 
includes links to automatically apply the diff to the editor, with red/green 
regions & accept/reject buttons.

Other useful features:

* Undo button to undo your last submission
* Clone button to clone your entire conversation
* Automatic checkpoints before applying diffs
* "Get second opinion" - asks another model to match or criticise the first model.

When you click "Continue conversation" from the Coding Agent or SQL-to-LINQ tool,
LINQPad transfers you to the Chat tool, incorporating a summary of the context
gained through the agentic workflow (such as data context schema, errors and
info on LINQPad-specific features that the model requested).

*/
