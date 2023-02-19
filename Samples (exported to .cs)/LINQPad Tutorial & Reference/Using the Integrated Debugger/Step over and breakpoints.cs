// LINQPad Program

// Whereas F11 steps into, F10 steps *over*. The nice thing about LINQPad's "step over" is how it handles
// breakpoints. Try setting a breakpoint in the Bar method, then press F10 to step over Foo. When the
// "step over" gets interrupted by the breakpoint, you're given an option to resume the original step (F5).

void Main()
{
	Foo();
	Foo();
	Foo();
}

void Foo()
{
	Bar();
}


void Bar()
{
	"Bar".Dump();
}