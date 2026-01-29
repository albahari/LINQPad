<Query Kind="Statements" />

// A AIRequestOptions object lets you specify a system prompt and other request parameters
// such as MaxTokens and ReasoningEffort.

using LINQPad.ObjectModel.AI;

string popularLeader = Util.ReadLine ("Enter the name of a popular leader");

var requestOptions = new AIRequestOptions
{
	SystemPrompt = $"You are an entertainer, who will answer questions using parody, in the style of {popularLeader}.",
	MaxTokens = 1000
};

Util.AI.Ask ("Why did you lose your last golf match?", requestOptions).Dump();