<Query Kind="Program">
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// To use programmatic benchmarking, go to the Query meny and choose "Add Programmatic Benchmark support"
// (you can try this with another query).
//
// This does a couple of things. First, it adds the following #load directive to your query:

#load "BenchmarkDotNet"

void Main()
{
	// Second, it adds a call to RunBenchmark (defined in BenchmarkDotNet.linq)
	RunBenchmark();
}

// Now you can apply the [Benchmark] attribute to any public method you wish to benchmark.
// To initiate benchmarking, just press F5.

[Benchmark]
public void BenchmarkDemo()   // Methods marked with [Benchmark] must be public!!!
{
	Thread.SpinWait (250);
}

// You can use other BenchmarkDotNet attributes - such as [Arguments] to test parameterized methods:

[Benchmark]
[Arguments (250)]
[Arguments (500)]
public void SpinWait (int iterations) => Thread.SpinWait (iterations);

byte[] data = new byte [100000];
HashAlgorithm sha1 = SHA1.Create();

// You can optionally define a public [GlobalSetup] method to execute initialization code.

[GlobalSetup]
public void BenchmarkSetup() => RandomNumberGenerator.Create().GetBytes (data);

[Benchmark]
public void TestSHA1() => sha1.ComputeHash (data);

// You can still benchmark an individual method ("soloing") by highlighting it and pressing Ctrl+Shift+B.
// Any [GlobalSetup] methods that you've defined will still be honored.

// You can also define classes containing [Benchmark] methods. Just make sure the classes are public.