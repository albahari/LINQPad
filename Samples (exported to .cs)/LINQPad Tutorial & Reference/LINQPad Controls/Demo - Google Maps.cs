// LINQPad Statements

using LINQPad.Controls
using System.Net
using System.Threading.Tasks

// This demonstrates how to use Google Maps, as well as JavaScript interop and custom event handling.
//
// Note that Google Maps requires an API key. You can obtain one here:
//    https://developers.google.com/maps/documentation/javascript/get-api-key

if (Util.BrowserEngine.IsMSIE) 
	throw new InvalidOperationException ("This functionality is not supported in IE. " +
	"Please enable the Chromium browser in Edit | Preferences > Results");

// Prompt for the API key on first use (and then store it securely):
string apiKey = Util.GetPassword ("Google Maps API key");

// Create a resizable DIV for the map and set its initial height:
var divMap = new Div();
divMap.HtmlElement.ID = "divMap";      // An explicit ID makes the GetMap function below easier to write.
divMap.Styles ["height"] = "80vh";     // Initial height = 80% of available window height.
divMap.Styles ["resize"] = "both";     // User-resizable
divMap.Styles ["overflow"] = "auto";
divMap.Dump ("Google maps. Right-click for latitude/longitude.");

// What we just did was equivalent to this:
// Util.RawHtml ("<div id='divMap' style='height:80vh; resize:both; overflow:auto' />").Dump();

// Define a JavaScript function to instantiate and configure the map (as per the Maps API documentation):
Util.HtmlHead.AddScript ("""
	async function GetMap()
	{
		const { Map } = await google.maps.importLibrary("maps");
		const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");
		const map = new Map(document.getElementById("divMap"), {
			center: { lat: 37.4239163, lng: -122.0947209 },
			zoom: 14,
			mapId: "4504f8b37365c3d0",
		});
		
		const marker = new AdvancedMarkerElement({
			map,
			position: { lat: 37.4239163, lng: -122.0947209 },
		});
		
		// Hook up a handler to the rightclick event to demo event handling:
		map.addListener('rightclick', function(event) {
			const lat = event.latLng.lat();
			const lng = event.latLng.lng();
			const location = `${lat}, ${lng}`;
			const rightClickEvent = new CustomEvent('rightClick', { detail: location });
			document.getElementById('divMap').dispatchEvent(rightClickEvent);
		});
	}
	""");

// Handle the custom event that we just defined on the C# side:
divMap.HtmlElement.AddEventListener ("rightClick",
	new[] { "detail" },
	(sender, args) =>
	{
		string location = args.Properties ["detail"];
		location.Dump ("Latitude/longitude");
	});

// Finally, load the Google Maps script with an instruction to invoke our GetMap JavaScript function when ready.
// (We do this last to ensure that the divMap element and the GetMap function exist.)
Util.HtmlHead.AddScriptFromUri ($"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=GetMap&libraries=maps,marker&v=beta");