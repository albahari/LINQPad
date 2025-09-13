<Query Kind="Statements">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// Most of the code that controls benchmarking is inside a script that you can customize
// called "BenchmarkDotNet.linq.  By editing this script, you can change the way that LINQPad
// interfaces with BenchmarkDotNet - and the way it displays results. Any changes you make
// to this script are merged with subsequent updates.
//
// You can change the way LINQPad behaves in zero-touch mode, as well as in programmatic mode.

new Hyperlinq (() => 
	Util.OpenScript (Path.Combine (Util.MyQueriesFolder, "BenchmarkDotNet.linq")),
	"Customize benchmarking behavior", true).Dump();			