// LINQPad Statements

// To stream the response, call GetResponseAsync with an Action<string>:

var response = await Util.AI
	.Ask ("Is gravity considered a fundamental force in physics?")
	.GetResponseAsync (ScriptCancelToken, chunk => Console.Write (chunk));
	
Util.Markdown (response.Text).Dump ("Complete response");

// response.Text will always equal the sum of the chunks when the await completes.

// You can also stream reasoning tokens, by including another Action<string> parameter with the call.