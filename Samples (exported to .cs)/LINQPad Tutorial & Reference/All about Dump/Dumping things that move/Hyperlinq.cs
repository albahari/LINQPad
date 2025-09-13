// LINQPad Statements

using System.Security.Cryptography;

// The Hyperlinq class has three uses.

// The first is to display ordinary hyperlinks:
new Hyperlinq ("https://www.linqpad.net", "LINQPad's home page").Dump();

// The second is to execute a delegate on demand:
new Hyperlinq (() => RSA.Create().ToXmlString (true).Dump(), "Generate public/private keypair").Dump();

// The third is to execute dynamically generated code on demand:
new Hyperlinq (ScriptLanguage.Statements, "for (int i = 0; i < 10; i++) i.Dump();", "Dynamically generated code").Dump();

// LINQPad also has a more low-level Hyperlink class in the LINQPad.Controls namespace
// see script://../../LINQPad_Controls