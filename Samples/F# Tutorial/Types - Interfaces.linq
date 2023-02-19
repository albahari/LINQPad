<Query Kind="FSharpProgram" />

type IPeekPoke = 
	abstract Peek: unit -> int
	abstract Poke: int -> unit
	
type Widget(initialState:int) = 
	/// The internal state of the Widget
	let mutable state = initialState

	// Implement the IPeekPoke interface
	interface IPeekPoke with 
		member x.Poke(n) = state <- state + n
		member x.Peek() = state 
		
	/// Has the Widget been poked?
	member x.HasBeenPoked = (state <> 0)


let widget = Widget(12) :> IPeekPoke

widget.Poke(4)
widget.Peek().Dump()

