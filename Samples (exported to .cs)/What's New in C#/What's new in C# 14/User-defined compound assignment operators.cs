// LINQPad Program

// In C# 14, you can explicitly overload compound operators such as +=.
//
// Prior to C# 14, you could overload only non-compound operators (such as +)
// and calls to += would result in a call to + followed by an assignment.

void Main()
{
	var n = new ThreadSafeInt (10);
	n += 5;
	n.Dump();
}

struct ThreadSafeInt
{
    public int Value;
	
	public ThreadSafeInt (int value) => Value = value;

	public void operator += (int x) => Interlocked.Add (ref Value, x);
}