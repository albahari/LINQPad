<Query Kind="Statements">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// The Hyperlinq class has three uses.

// The first is to display ordinary hyperlinks:
new Hyperlinq ("http://www.linqpad.net", "LINQPad's home page").Dump();

// The second is to execute a delegate on demand:
new Hyperlinq (() => RSA.Create().ToXmlString (true).Dump(), "Generate public/private keypair").Dump();

// The third is to execute dynamically generated code on demand:
new Hyperlinq (QueryLanguage.Statements, "for (int i = 0; i < 10; i++) i.Dump();", "Dynamically generated code").Dump();

