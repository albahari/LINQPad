<Query Kind="Statements" />

// You can choose any available model.
// The available models will depend on which provider(s) you've configured in LINQPad's AI Settings.
// You can access these via static members on the AIModel and AIProvider types:

using LINQPad.ObjectModel.AI;

AIModel.DefaultChatModel.Dump ("Default model", 1);

var model = AIModel.FindByName ("Gemini Flash") ?? AIModel.FindByName ("GPT");
Util.AI.Ask ("What's the capital of France?", model:model).Dump();

// To enumerate all models:
AIModel.All.Dump ("All Models", 2);

// To enumerate all providers:
AIProvider.All.Dump ("All Providers", 2);