<Query Kind="Expression" />

/* ACCESSING INTERNAL MEMBERS OF REFERENCED ASSEMBLIES

When you create a library in Visual Studio, it can sometimes be useful to call its internal methods from LINQPad.

To do this, add the following assembly attribute to your project in Visual studio:

[assembly: InternalsVisibleTo ("LINQPadQuery")]

*/