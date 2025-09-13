<Query Kind="Statements" />

/* Exactly how long does it take to execute a catch block, a lock statement, or a SHA512 hash?

Getting precise and repeatable results when performance-testing is suprisingly tricky!
Fortunately, there's a library for this purpose called BenchmarkDotNet, used extensively by Microsoft:
https://benchmarkdotnet.org/

LINQPad makes using BencharkDotNet as easy as pressing a key!
To demonstrate, highlight the following two lines of code and press Ctrl+Shift+B (Shift-Command-B on macOS): */

try   { throw new InvalidOperationException(); }
catch { }

/* LINQPad supports three modes of operation:

ZERO-TOUCH

	Select the code or method(s) you wish to benchmark and press Ctrl+Shift+B / Shift-Command-B (Script | Benchmark Selected Code).
	No modifications to your script are required!
	
	For a complete demo, see script://Benchmarking_-_zero_touch_(statements)
	                     and script://Benchmarking_-_zero_touch_(program)
	
PROGRAMMATIC

	Go to the Script menu and choose "Add Programmatic Benchmark Support".
	Then add the [Benchmark] attribute to the methods you wish to test.
	
	This lets you access advanced BenchmarkDotNet features while still using LINQPad's live results visualizer.
	Call RunBenchmark() to begin benchmarking.
	
	For a complete demo, see script://Benchmarking_-_programmatic

DIRECT

	You can also use BenchmarkDotNet directly, bypassing LINQPad's results visualizer.

	1. Add a NuGet package reference to BenchmarkDotNet
	2. Define class(es) in your script with methods to [Benchmark] as per BenchmarkDotNet documentation
	3. Call BenchmarkRunner.Run<ClassName>() in your Main method to start benchmarking.
	
	BenchmarkDotNet recognizes that it's running in LINQPad, and emits a syntax-colored log to the output window.	
	
	For a demo, see script://Benchmarking_-_direct
*/