<Query Kind="FSharpProgram" />

/// A simple string
let stringA  = "Hello"

/// A second simple string
let stringB  = "world"

/// "Hello world" computed using string concatentation
let stringC = stringA + " " + stringB
stringC.Dump()

/// "Hello world" computed using a .NET library function
let stringD = String.Join(" ",[| stringA; stringB |])
stringD.Dump()