<Query Kind="Statements" />

// Records are designed to work well with inheritance. We can subclass Person to Student and still
// fully utilize all features of records, including positional parameters and 'with' statements:

var student1 = new Student ("Joe", "Bloggs", 123);
var student2 = student1 with { FirstName = "Josephine" };

new { student1, student2 }.Dump();

public record Person (string FirstName, string LastName);

public record Student (string FirstName, string LastName, int StudentID) : Person (FirstName, LastName);