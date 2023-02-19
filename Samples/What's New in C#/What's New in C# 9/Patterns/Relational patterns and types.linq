<Query Kind="Statements" />

// The relational pattern implicitly tests for type.

object obj = 100.0; obj.GetType().Dump ();   // n is a double.

// The following prints true because n is a double and less than 200:
(obj is < 200.0).Dump ($"{obj} is less than (double)200.0");

// The following prints false because n is not an int:
(obj is < 200).Dump ($"{obj} is less than (int)200");

// The following prints true because we first test the type:
(obj is double and < 200).Dump ($"{obj} is less than (double)200");

// The following also prints true:
(obj is < 200 or < 200.0).Dump ($"{obj} is less than (int)200 or less than (double)200");