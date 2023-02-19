<Query Kind="FSharpProgram" />

/// A simple boolean value
let boolean1 = true

/// A second simple boolean value
let boolean2 = false

/// Compute a new boolean using ands, ors, and nots
let boolean3 = not boolean1 && (boolean2 || false)

boolean3.Dump()