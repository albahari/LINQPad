<Query Kind="Statements">
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

// You can reference the ASP.NET Core Framework (if installed) - just press F4 and tick
// the checkbox on the bottom right.

// The following script demonstrates how easy it is to host web pages using ASP.NET minimal API.

var app = WebApplication.CreateBuilder().Build();
app.MapGet ("/", () => "Hello from LINQPad!");

// Test API
Process.Start (new ProcessStartInfo ("http://localhost:5000") { UseShellExecute = true });

app.Run();

