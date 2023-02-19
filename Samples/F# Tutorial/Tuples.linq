<Query Kind="FSharpProgram" />

// A simple tuple of integers
let pointA = (1, 2, 3)
pointA.Dump()

// A simple tuple of an integer, a string and a double-precision floating point number
let dataB = (1, "fred", 3.1415)
dataB.Dump()

/// A function that swaps the order of two values in a tuple
let Swap (a, b) = (b, a)

(Swap (1, 2)).Dump ("Swap 1 and 2")
