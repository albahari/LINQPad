<Query Kind="FSharpProgram" />

/// A function that squares its input
let Square x = x*x
(Square 5).Dump ("Square of 5")

// Map a function across a list of values
let squares1 = List.map Square [1; 2; 3; 4]
let squares2 = List.map (fun x -> x*x) [1; 2; 3; 4]

squares1.Dump ("squares1")
squares2.Dump ("squares2")

// Pipelines
let squares3 = [1; 2; 3; 4] |> List.map (fun x -> x*x) 
let SumOfSquaresUpTo n = 
  [1..n] 
  |> List.map Square 
  |> List.sum
  
squares3.Dump ("squares3") 