<Query Kind="FSharpProgram" />

let int1 = 1
let int2 = 2
let int3 = int1 + int2

/// A function on integers
let f x = 2*x*x - 5*x + 3

/// The result of a simple computation 
let result = f (int3 + 4)
result.Dump()

/// Another function on integers
let increment x = x + 1
increment(10).Dump ("Increment 10")

/// Compute the factorial of an integer
let rec factorial n = if n=0 then 1 else n * factorial (n-1)
factorial(6).Dump ("6 Factorial")

/// Compute the highest-common-factor of two integers
let rec hcf a b =                       // notice: 2 parameters separated by spaces
	if a=0 then b
	elif a<b then hcf a (b-a)           // notice: 2 arguments separated by spaces
	else hcf (a-b) b
	// note: function arguments are usually space separated
	// note: 'let rec' defines a recursive function

(hcf 15 20).Dump ("Highest common factor of 15 and 20")