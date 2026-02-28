<Query Kind="Statements">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// The Hyperlinq class has three uses.

// The first is to display ordinary hyperlinks:
new Hyperlinq ("https://www.linqpad.net", "LINQPad's home page").Dump();

// The second is to execute a delegate on demand:
new Hyperlinq (
	() => RSA.Create().ToXmlString (true).Dump(),
	"Generate public/private keypair",
	runOnNewThread:true).Dump();
// runOnNewThread:true allows the delegate to run before the script has completed: this is useful if your script blocks.

// The third is to execute dynamically generated code on demand (in a new tab):
new Hyperlinq (ScriptLanguage.Statements, "for (int i = 0; i < 10; i++) i.Dump();", "Dynamically generated code").Dump();

// LINQPad also has a more low-level Hyperlink class in the LINQPad.Controls namespace
// see script://../../LINQPad_Controls