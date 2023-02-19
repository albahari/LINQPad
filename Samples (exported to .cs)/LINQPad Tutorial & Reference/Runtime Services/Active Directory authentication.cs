// LINQPad Statements

// LINQPad also provides methods to obtain authentication tokens via Microsoft's old
// Active Directory Authentication Library (ADAL) with support for interactive/multi-factor.
//
// Note that ADAL has been superceded by MSAL (Microsoft Authentication Library).
// Use Util.MSAL to access MSAL authentication (see preceding examples for demos).

string tenantID = "(your Azure tenant ID)";
string loginID = "user@domain.com";

// Ask the LINQPad host process to authenticate to the Azure Global Cloud interactively:

string token = Util.ActiveDirectory.AcquireTokenAsync (
	$"https://login.microsoftonline.com/{tenantID}",
	"https://management.core.windows.net/",
	loginID).Result.AccessToken;
	
token.Dump();

// For non-interactive Active Directory authentication (username+password), call the overload that takes a NetworkCredential.