<Query Kind="FSharpProgram" />

/// The empty list
let listA = [ ]           

/// A list with 3 integers
let listB = [ 1; 2; 3 ]
listB.Dump ("listB")

/// A list with 3 integers, note :: is the 'cons' operation
let listC = 1 :: [2; 3]    
listC.Dump ("listC")

/// Compute the sum of a list of integers using a recursive function
let rec SumList xs =
	match xs with
	| []    -> 0
	| y::ys -> y + SumList ys

/// Sum of a list
let listD = SumList [1; 2; 3]  
listD.Dump ("listD")

/// The list of integers between 1 and 10 inclusive 
let oneToTen = [1..10]
oneToTen.Dump ("oneToTen")

/// The squares of the first 10 integers
let squaresOfOneToTen = [ for x in 1..10 -> x*x ]
squaresOfOneToTen.Dump ("squaresOfOneToTen")