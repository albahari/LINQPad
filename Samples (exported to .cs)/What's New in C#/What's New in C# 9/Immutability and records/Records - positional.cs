// LINQPad Statements

// You can eliminate almost all boilerplate with *positional parameters*.
// This makes records useful for simple types that just combine or hold data.

new Person ("Joe", "Bloggs").Dump();

// Uncomment this to see what the compiler generates:
// Util.OpenILSpy (typeof (Person));

// Notice the round brackets in the record definition:
public record Person (string FirstName, string LastName);

// The compiler automatically generates an init-only property per parameter.
// It also generates a constructor (called a 'primary constructor') and a deconstructor.
