<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// When you set the query language to "C# Program", benchmarking becomes more powerful.
//
// We'll start by testing the performance of an uncontended lock.
//
// This time, we'll construct the locker object in a field initializer (outside the Main method).
// This ensures that the construction time is not included in the benchmarking time.
object locker = new();

void Main()
{
	// Highlight the following line of code and press Ctrl+Shift+B to benchmark:
	lock (locker) {}
}

string testString = "The QUICK brown Fox jumps OVER the LAZY dog, WHILE thinking OF a SECURE pAsSwrd!@#$%^&*()[]{};':.";

// You can also benchmark complete method(s). Select the four methods below and press Ctrl+Shift+B:

void ToUpper() =>            testString.ToUpper();
void ToUpperInvariant() =>   testString.ToUpperInvariant();
void ToLower() =>            testString.ToLower();
void ToLowerInvariant() =>   testString.ToLowerInvariant();

// Notice that the results graph includes margin of error, so you can easily know whether differences are meaningful.

// Let's now compare the performance of the System.Random class with the cyptographically strong RandomNumberGenerator.
// Here are the field initializers we need to set this up:

Random random = new();
RandomNumberGenerator rng = RandomNumberGenerator.Create();
byte[] buffer = new byte[1000];

// Select the following two lines and press Ctrl+Shift+B:

void SystemRandom() => random.NextBytes (buffer);
void CryptoRandom() => rng.GetBytes (buffer);

// Now we'll compare the performance of various hashing algorithms.
// Let's create a class for this, so that we can initialize test data in its constructor.

class HashTest
{
	byte[] data = new byte [100000];

	public HashTest()   // (constructor must be public, so BenchmarkDotNet can access it)
	{
		// Stuff we do here gets excluded from benchmarking.
		RandomNumberGenerator.Create().GetBytes (data);
	}
	
	HashAlgorithm sha1 = SHA1.Create();
	HashAlgorithm sha256 = SHA256.Create();
	HashAlgorithm sha512 = SHA512.Create();
	
	// Select the three methods below and press Ctrl+Shift+B:

	void TestSHA1() => sha1.ComputeHash (data);
	void TestSHA256() => sha256.ComputeHash (data);
	void TestSHA512() => sha512.ComputeHash (data);	
}