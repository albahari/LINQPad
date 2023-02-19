<Query Kind="FSharpProgram" />

/// A 2-dimensional vector
type Vector2D(dx:float, dy:float) = 
	// The pre-computed length of the vector
	let length = sqrt(dx*dx + dy*dy)
	/// The displacement along the X-axis
	member v.DX = dx
	/// The displacement along the Y-axis
	member v.DY = dy
	/// The length of the vector
	member v.Length = length
	// Re-scale the vector by a constant
	member v.Scale(k) = Vector2D(k*dx, k*dy)
	
(Vector2D (3.2, 4.5)).Dump()	