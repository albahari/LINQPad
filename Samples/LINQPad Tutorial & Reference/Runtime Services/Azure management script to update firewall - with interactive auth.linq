<Query Kind="Program">
  <NuGetReference>Azure.Identity</NuGetReference>
  <NuGetReference>Azure.ResourceManager.Resources</NuGetReference>
  <NuGetReference>Azure.ResourceManager.Sql</NuGetReference>
  <Namespace>Azure</Namespace>
  <Namespace>Azure.Core</Namespace>
  <Namespace>Azure.Identity</Namespace>
  <Namespace>Azure.ResourceManager</Namespace>
  <Namespace>Azure.ResourceManager.Resources</Namespace>
  <Namespace>Azure.ResourceManager.Sql</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

// This script demonstrates how to add the current IP address to the firewall of an Azure SQL Server database,
// using the Azure.ResourceManager API. No passwords are stored or handled because we authenticate interactively.
//
// You can use this as a base for your own Azure management scripts.

async Task Main()
{
	// Edit the following if you're not using the Azure public cloud:
	string authEndPoint = Util.AzureCloud.PublicCloud.AuthenticationEndpoint;

	string tenantID = "mydomain.com";
	string userHint = $"user@{tenantID}";
	
	string subscriptionName = "(your subscription name)";
	string resourceGroupName = "(resource group name)";        // example: "Default-SQL-SouthCentralUS"
	string dbServerName = "(azure database server name)";      // example: "er0q3g3629"
	string firewallRuleName = "Test";

	// Ask an external web app for our IP address:
	string ip = await GetMyIPAddress().Dump ("My IP address");

	// Authenticate to the Azure API:
	var credential = new LINQPadTokenCredential (Util.AzureCloud.PublicCloud.AuthenticationEndpoint + tenantID, userHint);
	var client = new ArmClient (credential);
	
	// Get the subscription 
	SubscriptionResource subscription = client.GetSubscriptions().Single (s => s.Data.DisplayName == subscriptionName);

	// Update the firewall rule
	await UpdateFirewallRule (subscription, resourceGroupName, dbServerName, firewallRuleName, ip);
}

async Task UpdateFirewallRule (SubscriptionResource subscription, string resourceGroupName, string dbServerName,
	string firewallRuleName, string ip)
{
	ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
	ResourceGroupResource resourceGroup = await resourceGroups.GetAsync (resourceGroupName);
	var server = resourceGroup.GetSqlServer (dbServerName).Value;
	
	// Dump existing firewall rules...
	server.GetSqlFirewallRules().Select (s => s.Get().Value.Data).Dump ("Existing firewall rules", depth:1);
	
	Console.Write ($"Updating rule for {dbServerName}... ");
	
	server.GetSqlFirewallRules().CreateOrUpdate (
		WaitUntil.Completed,
		firewallRuleName,
		new SqlFirewallRuleData { Name = firewallRuleName, StartIPAddress = ip, EndIPAddress = ip, }).WaitForCompletion();
	
	Console.WriteLine ("done");
}

// You can copy this class into your own scripts, or put it into a script that you #load. 
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

public static Task<string> GetMyIPAddress() => new HttpClient().GetStringAsync ("https://api.ipify.org/?format=text");