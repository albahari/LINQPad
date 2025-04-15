<Query Kind="Statements" />

// LINQPad provides built-in methods for authenticating to Azure and OAuth endpoints.
// This includes support for interactive multi-factor authentication.
//
// This is useful for a couple of reasons:
//   (a) It requires less code than using the Microsoft Authentication Library (MSAL) directly.
//   (b) LINQPad stores the authentication cache in the GUI host process, so you don't have to keep re-authenticating.
//
// By default, LINQPad stores access tokens in memory. If you prefer, you can persist them to disk by clicking a
// checkbox on the authentication dialog. This will mean:
//   (a) not having to re-authenticate after restarting LINQPad
//   (b) being able to share tokens between multiple instances of LINQPad
// LINQPad uses the Microsoft.Identity.Client.Extensions.Msal library to perform this job securely.

// In this example, we authenticate to the Azure Global Cloud Management API interactively.

string tenantID = "mydomain.com";
string userHint = $"user@{tenantID}";

// Use LINQPad's AzureCloud helper class to get the correct constants for the Azure endpoints:
string azureAuth = Util.AzureCloud.PublicCloud.AuthenticationEndpoint;
string scope = Util.AzureCloud.PublicCloud.ManagementApiDefaultScope;

// Now we can ask the LINQPad host process to authenticate:
var authResult = await Util.MSAL.AcquireTokenAsync (azureAuth + tenantID, scope, userHint);
authResult.Dump();
authResult.AccessToken.Dump ("Here is the access token");

// LINQPad does all the work for you in properly calling MSAL (AcquireTokenInteractive/AcquireTokenSilent)
// with useful defaults, and also ensures that the MFA window stays in front of the LINQPad host window.

// For non-interactive (username+password), call Util.MSAL.AcquireTokenByUsernamePasswordAsync