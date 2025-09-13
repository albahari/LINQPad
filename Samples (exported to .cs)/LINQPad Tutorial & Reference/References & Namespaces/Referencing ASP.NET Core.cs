// LINQPad Statements

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

// You can reference the ASP.NET Core Framework (if installed) - just press F4 and tick
// the checkbox on the bottom right.

// The following script demonstrates how easy it is to host web pages using ASP.NET minimal API.

var app = WebApplication.CreateBuilder().Build();
app.MapGet ("/", () => "Hello from LINQPad!");

// Test API
Process.Start (new ProcessStartInfo ("http://localhost:5000") { UseShellExecute = true });

app.Run();

