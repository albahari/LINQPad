<Query Kind="Statements">
  <Namespace>System.Dynamic</Namespace>
</Query>

// You can dump dynamic objects, but there's a trick.

dynamic expando = new ExpandoObject();

expando.FirstName = "Joe";
expando.LastName = "Albahari";
expando.City = "Perth";
expando.PostCode = "6020";

// You can't call extension methods on dynamic objects in C#. Therefore, you can't call Dump on expandoObject!

// However, we can do this:
LINQPad.Extensions.Dump (expando);

// Or this:
((object)expando).Dump();

// Or this:
Console.WriteLine (expando);     // LINQPad re-routes Console.WriteLine to the Dump pipeline

// They all have the same effect.