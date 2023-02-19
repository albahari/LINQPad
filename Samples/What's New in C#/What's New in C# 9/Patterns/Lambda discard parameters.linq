<Query Kind="Expression" />

// The underscore can now be used as a 'discard' in lambda expressions:

"Password".Select (_ => "*")

// (This feature is more useful when there are multiple parameters, because they can all be _)
