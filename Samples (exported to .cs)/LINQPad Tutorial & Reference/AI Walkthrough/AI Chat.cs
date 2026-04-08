// LINQPad Statements

/* LINQPad's AI Chat is a general-purpose non-agentic chat tool.

To activate it, either press Ctrl+P / Command-P and choose a non-agentic prompt,
or press Alt+I / Command-I (for the default system prompt).

**For LINQPad coding tasks, you typically get better results with the coding agent**

Unlike the coding agent, the chat tool does not send additional information
to the model. Everything that's sent and received is visible in the chat.

For this reason, you can use this a prompt engineering tool or a general AI
chat tool, with the ability to control the system prompt and rewrite any part
of the conversation each time you submit. With an empty system prompt, the 
model has no idea that it's in LINQPad.

The chat tool has a number of editor integration features that make it work
well as a coding tool, however. The first is the "Enable refactoring" toggle
in the top-right. When enabled, this updates the system prompt with instructions
to generate a unified diff in response to code editing requests. When LINQPad
sees a diff in the output, it includes links to automatically apply the diff
to the editor, with red/green regions & accept/reject buttons.

Other useful features:

* Undo button to undo your last submission
* Clone button to clone your entire conversation
* Automatic checkpoints before applying diffs
* "Get second opinion" - asks another model to match or criticise the first model.

When you click "Continue conversation" from the Coding Agent or SQL-to-LINQ tool,
LINQPad transfers you to the Chat tool, incorporating a summary of the context
gained through the agentic workflow (such as data context schema, errors and
info on LINQPad-specific features that the model requested). Keep in mind that
because the chat tool is non-agentic, it does not have the ability to automatically
gain additional context from that point on.

*/
