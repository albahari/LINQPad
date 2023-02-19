<Query Kind="FSharpProgram" />

/// A dictionary with integer keys and string values
let lookupTable = dict [ (1, "One"); (2, "Two") ]
lookupTable.Dump ("lookupTable")

let oneString = lookupTable[1]
oneString.Dump ("oneString")

// For some other common data structures, see:
//   System.Collections.Generic
//   Microsoft.FSharp.Collections
//   Microsoft.FSharp.Collections.Seq
//   Microsoft.FSharp.Collections.Set
//   Microsoft.FSharp.Collections.Map