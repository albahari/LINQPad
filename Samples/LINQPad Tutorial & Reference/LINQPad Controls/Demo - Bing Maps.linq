<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// This demonstrates how to use Bing Maps, as well as JavaScript interop and custom event handling.
// NB: The Bing Maps API is in the process of being retired. See the 'Google Maps' demo for an alternative.

bool haveMapsAPIKey = false;   // Change this to true if you have an Bing Maps API key

if (Util.BrowserEngine.IsMSIE) 
	throw new InvalidOperationException ("This functionality is not supported in IE. " +
	"Please enable the Chromium browser in Edit | Preferences > Results");

// If we have an API key, prompt for it on first use (and then store it securely):
string apiKey = haveMapsAPIKey ? Util.GetPassword ("Bing Maps API key") : "";

// Create a resizable DIV for the map and set its initial height:
var divMap = new Div();
divMap.HtmlElement.ID = "divMap";      // An explicit ID makes the GetMap function below easier to write.
divMap.Styles ["height"] = "80vh";     // Initial height = 80% of available window height.
divMap.Styles ["resize"] = "both";     // User-resizable
divMap.Styles ["overflow"] = "auto";
divMap.Dump ("Bing map. Right-click for latitude/longitude.");

// What we just did was equivalent to this:
// Util.RawHtml ("<div id='divMap' style='height:80vh; resize:both; overflow:auto' />").Dump();

// Define a JavaScript function to instantiate and configure the map (as per the Maps API documentation):
Util.HtmlHead.AddScript (
@"function GetMap() {
	var map = new Microsoft.Maps.Map ('#divMap');

	// Load traffic module.
	Microsoft.Maps.loadModule ('Microsoft.Maps.Traffic', function () {
		// Create an instance of the traffic manager and bind to map.
		trafficManager = new Microsoft.Maps.Traffic.TrafficManager (map);

		// Display the traffic data.
		trafficManager.show();
	});
	
	// Hook up a handler to the rightclick event to demo event handling:
	Microsoft.Maps.Events.addHandler (map, 'rightclick', args => { 
		var point = new Microsoft.Maps.Point (args.getX(), args.getY());
		var loc = args.target.tryPixelToLocation (point);
		
		// Forward event to C# by dispatching a CustomEvent on divMap:
		divMap.dispatchEvent (new CustomEvent ('rightClick', { detail: [loc.latitude, loc.longitude] }));
	});		
}");

// Handle the custom event that we just defined on the C# side:
divMap.HtmlElement.AddEventListener ("rightClick",
	new[] { "detail" },
	(sender, args) =>
	{
		string location = args.Properties ["detail"];
		location.Dump ("Latitude/longitude");
	});

// Finally, load the Bing Maps script with an instruction to invoke our GetMap JavaScript function when ready.
// (We do this last to ensure that the divMap element and the GetMap function exist.)
Util.HtmlHead.AddScriptFromUri ($"http://www.bing.com/api/maps/mapcontrol?callback=GetMap&key={apiKey}'");
