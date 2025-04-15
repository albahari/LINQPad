// LINQPad Statements

using System.Threading.Tasks

// The Util.CacheAsync method is optimized for asynchronous data (i.e., tasks).
// It's exactly like Util.Cache except that it includes additional logic to 
// prevent faulted tasks from being cached.

var delayedValue1 = await Util.CacheAsync (DelayedValue, "someKey");
delayedValue1.Dump();

async Task<int> DelayedValue()
{
	await Task.Delay (3000);
	return 123;
}

// Should you prefer to cache faulted tasks, use Util.Cache instead of Util.CacheAsync.
var delayedValue2 = await Util.Cache (DelayedValue, "someOtherKey");
delayedValue2.Dump();
