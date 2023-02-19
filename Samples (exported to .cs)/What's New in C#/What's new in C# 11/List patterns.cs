// LINQPad Statements

// List patterns work with any collection type that is countable (with a Count/Length property)
// and indexable (with an int-type indexer). Following is a demo of each new list pattern.

int[] numbers = { 0, 1, 2, 3, 4 };

if (numbers is [0, 1, 2, 3, 4])
	"Numbers is { 0, 1, 2, 3, 4 }".Dump();

if (numbers is [0, ..])
	"Numbers starts with 0".Dump();

if (numbers is [0, _, _, _, _])
	"Numbers starts with 0, and has 5 elements".Dump();

if (numbers is [_, _, _, _, var last])
	last.Dump ("Last number in the series of 5");

if (numbers is [0, .. var rest])
	rest.Dump ("Numbers after the zero");

if (numbers is [0, .. var middle, 4])       // "slice"
	middle.Dump ("Numbers in the middle");

// The "slice" (middle) can be used only once, so the following is prohibited:
// if (numbers is [0, .. var middle1, 2, .. var middle2, 4])
//    ...
	
// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/list-patterns.md