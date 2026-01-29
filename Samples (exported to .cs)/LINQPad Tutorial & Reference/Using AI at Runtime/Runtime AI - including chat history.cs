// LINQPad Statements

// With a AIRequestOptions object, you can specify additional request parameters,
// including a prior chat history.

using LINQPad.ObjectModel.AI;

string firstQuestion = "What's the capital of France?";
var firstResponse = await Util.AI.Ask (firstQuestion).GetResponseAsync();
firstResponse.Dump ("First response");

var requestOptions = new AIRequestOptions();
requestOptions.ChatHistory.Add (new AIMessage (AIRole.User, firstQuestion));
requestOptions.ChatHistory.Add (new AIMessage (AIRole.Assistant, firstResponse.Text));

var followupResponse = await Util.AI.Ask ("How often do you get asked this?", requestOptions).GetResponseAsync();
followupResponse.Text.Dump ("Followup response");