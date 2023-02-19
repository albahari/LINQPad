<Query Kind="FSharpProgram" />

/// Create an array 
let arr = Array.create 4 "hello"
arr[1] <- "world"
arr[3] <- "don"
arr.Dump ("arr")

/// Compute the length of the array by using an instance method on the array object
let arrLength = arr.Length        
arrLength.Dump ("arrLength")

// Extract a sub-array using slicing notation
let front = arr[0..2]
front.Dump ("front")