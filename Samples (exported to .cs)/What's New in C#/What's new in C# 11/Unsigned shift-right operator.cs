// LINQPad Statements

// C# now has an unsigned shift-right operator (>>>).

// Whereas the standard shift-right operator (>>)  performs an arithmetic shift on signed types,
//         the unsigned shift-right operator (>>>) performs a  logical    shift on (all)  types.
//
// In other words, >>> always set the high-order bits to zero.

int x = int.MinValue;

Util.WithStyle (
	new
	{
		Original = Convert.ToString (x, toBase: 2),
		RightShift = Convert.ToString ((x >> 1), toBase: 2),
		UnsignedRightShift = Convert.ToString ((x >>> 1), toBase: 2)
	},
	"text-align:right").Dump();
	
// (The new operator has been introduced to help with generic math.)

// More info: https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/unsigned-right-shift-operator.md