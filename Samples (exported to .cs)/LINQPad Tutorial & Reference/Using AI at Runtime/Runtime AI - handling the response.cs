// LINQPad Statements

// To manually handle the response, call GetResponse() or GetResponseAsync()

var response = await Util.AI.Ask ("What's the capital of France?").GetResponseAsync ();
response.Text.Dump();

// You can optionally specify a reasoning effort, on a scale of 0 to 1 (default is 0 for no reasoning).

var response2 = await Util.AI.Ask ("What's the capital of France?", 0.5).GetResponseAsync ();
response2.Text.Dump ("Result");
response2.Reasoning.Dump ("Reasoning");