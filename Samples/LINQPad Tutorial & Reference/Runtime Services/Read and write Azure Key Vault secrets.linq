<Query Kind="Program">
  <NuGetReference>Azure.Identity</NuGetReference>
  <NuGetReference>Azure.Security.KeyVault.Secrets</NuGetReference>
  <Namespace>Azure</Namespace>
  <Namespace>Azure.Core</Namespace>
  <Namespace>Azure.Identity</Namespace>
  <Namespace>Azure.Security.KeyVault.Secrets</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// This script demonstrates how to access the Azure Vault API using LINQPad's authentication helper.

void Main()
{	
	string tenantID = "mydomain.com";
	string userHint = $"user@{tenantID}";
	string keyVaultUri = "https://mykeyvaultname.vault.azure.net";   // Set this to your Azure KeyVault URI

	VaultSecret.Save (keyVaultUri, "test-secret", "this is a secret", tenantID, userHint);
	VaultSecret.Get (keyVaultUri, "test-secret", tenantID, userHint).Dump();
}

// You can copy this class into your own scripts, or save it to a script that you #load. 
static class VaultSecret
{
	/// <summary>Saves a secret to Azure Key Vault</summary>
	public static void Save (string keyVaultUri, string secretName, string value, string tenantID,
		string userIDHint = null, DateTimeOffset? expiresOn = null)
	{
		var client = GetClient (keyVaultUri, tenantID, userIDHint);
		var secret = new KeyVaultSecret (secretName, value);
		if (expiresOn.HasValue) secret.Properties.ExpiresOn = expiresOn.Value;
		client.SetSecret (secret);
	}

	/// <summary>Retrieves a secret from Azure Key Vault</summary>
	public static string Get (string keyVaultUri, string secretName, string tenantID, string userIDHint = null)
	{
		var client = GetClient (keyVaultUri, tenantID, userIDHint);
		return client.GetSecret (secretName).Value.Value;
	}

	static SecretClient GetClient (string keyVaultUri, string tenantID, string userIDHint = null)
	{
		var cloud = Util.AzureCloud.FindByVaultHostOrUri (keyVaultUri) ?? Util.AzureCloud.PublicCloud;
		var credential = new LINQPadTokenCredential (cloud.AuthenticationEndpoint + tenantID, userIDHint);
		return new SecretClient (new Uri (keyVaultUri), credential);
	}
}

class LINQPadTokenCredential : TokenCredential
{
	public readonly string Authority, UserIDHint;

	public LINQPadTokenCredential (string authority, string userIDHint) => (Authority, UserIDHint) = (authority, userIDHint);

	public override AccessToken GetToken (TokenRequestContext requestContext, CancellationToken cancellationToken)
		=> GetTokenAsync (requestContext, cancellationToken).Result;

	public override async ValueTask<AccessToken> GetTokenAsync (TokenRequestContext requestContext,
																CancellationToken cancelToken)
	{
		// Call LINQPad's AcquireTokenAsync method to authenticate interactively, and cache token in the LINQPad GUI.
		var auth = await Util.MSAL.AcquireTokenAsync (Authority, requestContext.Scopes, UserIDHint).ConfigureAwait (false);
		return new AccessToken (auth.AccessToken, auth.ExpiresOn);
	}

}
