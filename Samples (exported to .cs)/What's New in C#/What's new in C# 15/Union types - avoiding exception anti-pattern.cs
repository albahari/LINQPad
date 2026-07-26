// LINQPad Program

using System.Net.Http;
using System.Net.Sockets;

// NB: To run the C# 15 samples, you must:
// - install both .NET 10 and .NET 11 preview
// - Go to Settings / Scripts and enable *both* C# language preview options

// With unions, you can avoid the anti-pattern of using exceptions to pass data.
// Instead, create a record to explicitly expose each of the possible outcomes.

union PaymentCardResult (Accepted, Declined, NetworkError);

record struct Accepted (string PaymentToken);
record struct Declined (string Reason, bool RetrySuggested);
record struct NetworkError (string ErrorMessage, Exception Exception);

void Main()
{
	PaymentCardResult result = CaptureCharge ("1234-1234-1234-1234");
	string msg = result switch
	{
		// Benefit from exhaustive pattern matching - the compiler warns you when you forget a case.
		Accepted a => $"Accepted: token {a.PaymentToken}",
		Declined d => $"Declined: {d.Reason} (Retry: {d.RetrySuggested})",
		NetworkError n => $"Network error: {n.ErrorMessage} ({n.Exception.Message})",
		null => "sadf"
	};
	msg.Dump();
}

PaymentCardResult CaptureCharge (string creditCardNumber) =>
	new Random().Next (3) switch
	{
		// Leverage the implicit conversion from each of the member types to the Union:
		0 => new Accepted ("52732935A"),
		1 => new Declined ("Insufficient funds", false),
		_ => new NetworkError ("DNS error", new HttpRequestException ("DNS error"))
	};
	
// Using union types here is safer than throwing a PaymentDeclinedException, which callers
// can easily forget to handle. Exceptions also cause trouble with iterators, lazy evaluation,
// and inversion of control, fundamentally whenever the place and time of execution are decoupled.


namespace System.Runtime.CompilerServices
{
	// The current .NET 11 previews require that we define this polyfill ourselves. This will be fixed in future previews.
	[AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
	public sealed class UnionAttribute : Attribute;

	public interface IUnion
	{
		object Value { get; }
	}
}