<Query Kind="Statements" />

// You can interactively explore the type of any unencapsulated object in ILSpy as follows:

new Regex ("test").Uncapsulate()._code.OpenILSpy();

// This is a shortcut for doing this:
//
// Type type = new Regex ("test").Uncapsulate()._code.GetType();
// Util.OpenILSpy (type);