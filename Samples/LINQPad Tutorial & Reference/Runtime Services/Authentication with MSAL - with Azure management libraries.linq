<Query Kind="Program">
  <NuGetReference>Azure.Identity</NuGetReference>
  <NuGetReference>Azure.ResourceManager.Resources</NuGetReference>
  <Namespace>Azure.Core</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Azure.ResourceManager</Namespace>
</Query>

// To use any of the Azure.* management libraries, you must authenticate by providing a TokenCredential
// (Azure.Core.TokenCredential in Azure.Identity.dll).

// Here's the code you need to define a TokenCredential that works with LINQPad's authentication manager:

public class LINQPadTokenCredential : TokenCredential
{
	public readonly string Authority, UserIDHint;

	public LINQPadTokenCredential (string authority, string userIDHint) =>
		(Authority, UserIDHint) = (authority, userIDHint);

	public override AccessToken GetToken (TokenRequestContext requestContext, CancellationToken cancelToken)
		=> GetTokenAsync (requestContext, cancelToken).Result;

	public override async ValueTask<AccessToken> GetTokenAsync (TokenRequestContext requestContext,
	                                                            CancellationToken cancelToken)
	{
		// Call LINQPad's AcquireTokenAsync method to authenticate interactively, and cache token in the LINQPad GUI.
		var auth = await Util.MSAL.AcquireTokenAsync (Authority, requestContext.Scopes, UserIDHint).ConfigureAwait (false);
		return new AccessToken (auth.AccessToken, auth.ExpiresOn);
	}
}

// And here's how to use it:

void Main()
{
	// Edit this if you're not using Azure Public Cloud
	string authEndPoint = Util.AzureCloud.PublicCloud.AuthenticationEndpoint;
	
	string tenantID = "mydomain.com";
	string userHint = $"user@{tenantID}";

	// Authenticate to the Azure management API:
	var credential = new LINQPadTokenCredential (authEndPoint + tenantID, userHint);
	var client = new ArmClient (credential);

	// Dump the default subscription:
	client.GetDefaultSubscription().Data.Dump (1);
}
/* TIP:

Save this script to "My Queries" - give it a name such as "Azure Credentials".
Then whenever you need to authenticate to Azure, put the following directive into your query:

#load "Azure Credentials"	

*/

