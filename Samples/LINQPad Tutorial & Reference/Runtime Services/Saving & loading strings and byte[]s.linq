<Query Kind="Statements" />

// You can easily save/load strings and byte arrays into named slots.
//
// Slots are shared between all scripts and are stored in %APPDATA%.

Util.SaveString ("LINQPad.DemoString", "Foo");
Util.LoadString ("LINQPad.DemoString").Dump();

Util.SaveBytes ("LINQPad.DemoBytes", new byte[] { 1, 2, 3 });
Util.LoadBytes ("LINQPad.DemoBytes").Dump();

// NOTE: The data is not encrypted, so don't use this to save/store passwords.
// For passwords, use Util.GetPassword/SetPassword (see below).
// (GetPassword also prompts the user for a value if nothing has been stored.)