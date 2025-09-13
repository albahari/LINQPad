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

// The following script demonstrates how to run a web API application using ASP.NET minimal API.
// In this case, we're exposing and endpoint that queries data from a SQLite demo database..

// As with the previous sample, you don't need any NuGet packages when using ASP.NET.
// Just press F4 and tick the ASP.NET checkbox on the bottom-right.

var app = WebApplication.CreateBuilder().Build();

app.MapGet ("/api/albums", (() =>
	 from a in Albums
	 select new { a.AlbumId, a.Title, Artist = a.Artist.Name }));

app.MapGet ("/api/albums/{id}", ((int id) => Albums
	 .Select (a => new { a.AlbumId, a.ArtistId, a.Title })
	 .FirstOrDefault (a => a.AlbumId == id)));

// Test API
string uriBase = "http://localhost:5000/api/";
StartWebBrowser ($"{uriBase}albums");
StartWebBrowser ($"{uriBase}albums/1");

app.Run();

void StartWebBrowser (string uri) =>
	Process.Start (new ProcessStartInfo (uri) { UseShellExecute = true });