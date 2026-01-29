// LINQPad Statements

// If you've set up an AI provider in LINQPad, you can access it easily from within a script.

// The easiest way to get started is to call Util.AI.Ask, and dump the output.
// This will automatically stream the output to the results window, using LINQPad's markdown renderer.

Util.AI.Ask ("What physics principles are required to implement GPS?").Dump();

// Note that by default, results are cached, so if you call an AI method again with identical parameters,
// the result will appear immediately. You can disable this by calling Util.AI.Ask with bypassCache:true.