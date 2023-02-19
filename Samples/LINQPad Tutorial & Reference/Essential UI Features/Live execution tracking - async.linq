<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// LINQPad also tracks asynchronous operations (awaits).

#LINQPad optimize-       // Force debug mode on (just in case you've enabled 'release mode' in Preferences)

while (true)
{
	await Hello();
	await World();
}

async Task Hello()
{
	Console.Write ("Hello, ");
	await Task.Delay (1000);
}

async Task World()
{
	Console.WriteLine ("World");
	await Task.Delay (1000);
}

// Pressing Shift+Ctrl+J moves between the pending asynchronous operations.
// See query://../Using_Advanced_C#_Features_in_LINQPad for more info on async and await
