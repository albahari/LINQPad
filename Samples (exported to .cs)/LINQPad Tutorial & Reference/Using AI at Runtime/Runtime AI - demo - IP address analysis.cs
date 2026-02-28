// LINQPad Statements

using LINQPad.ObjectModel.AI;
using System.Net.Http;
using System.Threading.Tasks;

/* LINQPad's AI coding agent knows about Util.AI.Ask, so it can write code for you!
 
   This script was written by pressing Ctrl+I / Command-I and typing the following:
      "Write a script that uses AI to analyze an IP address"
*/

// Fetch the user's public IP as the default
using var http = new HttpClient();
var myIp = await http.GetStringAsync("https://api.ipify.org/?format=text");

var ip = Util.ReadLine("Enter an IP address to analyze", myIp.Trim());

// Fetch geo/IP info from a free API
var ipInfo = await http.GetStringAsync($"http://ip-api.com/json/{ip}");
ipInfo.Dump("Raw IP Info");

// Ask AI to analyze
var prompt = $"""
	Analyze the following IP address: {ip}
	
	Here is geolocation/network data for this IP:
	{ipInfo}
	
	Please provide:
	1. A summary of who owns/operates this IP
	2. Geographic location details
	3. Common uses or reputation of this IP range
	4. Any security considerations or noteworthy information
	5. Whether this IP is likely a proxy, VPN, datacenter, or residential address
	6. Any other relevant information about that IP
	""";

var options = new AIRequestOptions
{
	SystemPrompt = "You are a network security analyst. Provide clear, concise analysis of IP addresses.",
	MaxTokens = 1500
};

Util.AI.Ask(prompt, options).Dump("AI Analysis");