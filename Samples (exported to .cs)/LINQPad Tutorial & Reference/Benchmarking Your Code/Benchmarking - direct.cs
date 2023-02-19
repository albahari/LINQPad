// LINQPad Program

#LINQPad optimize+

#r: "nuget: BenchmarkDotNet"

using BenchmarkDotNet.Attributes
using BenchmarkDotNet.Configs
using BenchmarkDotNet.Running
using System.Security.Cryptography

// To use BenchmarkDotNet directly, add a NuGet reference to BenchmarkDotNet.
// Then you can use BenchmarkDotNet much as you would in Visual Studio.

// Although you don't get LINQPad's live result visualizer, BenchmarkDotNet recognizes
// that it's running inside LINQPad, and emits nicely colored output.

// Note that you must explicitly enable compiler optimizations:


void Main()
{
	Util.AutoScrollResults = true;
	BenchmarkRunner.Run<Md5VsSha256>();
}

[ShortRunJob]
public class Md5VsSha256
{
	private const int N = 10000;
	private readonly byte[] data;

	private readonly SHA256 sha256 = SHA256.Create();
	private readonly MD5 md5 = MD5.Create();

	public Md5VsSha256()
	{
		data = new byte [N];
		new Random (42).NextBytes (data);
	}

	[Benchmark]
	public byte[] Sha256() => sha256.ComputeHash (data);

	[Benchmark]
	public byte[] Md5() => md5.ComputeHash (data);
}