<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// The easiest and cleanest way to use a control in a JavaScript library is usually to write
// a reusable custom control to wrap it.

// The following illustrates how to wrap the mapping control in leaflet.js library.

void Main()
{
	var map = new LeafletMap (37.4239163, -122.0947209, zoom: 14, showMarker: true);
	map.RightClick += (sender, location) => location.Dump ("Latitude/longitude");
	map.Dump ("Leaflet/OpenStreetMap. Right-click for latitude/longitude.");
}

// Start by subclassing Control
class LeafletMap : Control
{
	public double Latitude { get; set { field = value; Update(); } }
	public double Longitude { get; set { field = value; Update(); } }
	public int Zoom { get; set { field = value; Update(); } }
	public bool ShowMarker { get; set { field = value; Update(); } }

	public string Width { get => Styles ["width"]; set => Styles ["width"] = value; }
	public string Height { get => Styles ["height"]; set => Styles ["height"] = value; }	

	public event EventHandler<string> RightClick;

	// We're basing this control on a Div
	public LeafletMap (double latitude, double longitude, int zoom = 13, bool showMarker = false, string width = "100%", string height = "85vh")
		: base ("div")
	{
		Latitude = latitude;
		Longitude = longitude;
		Zoom = zoom;
		ShowMarker = showMarker;
		Width = width;
		Height = height;
	}
	
	// The OnRendering method fires just *before* the control is dumped.
	protected override void OnRendering (EventArgs e)
	{
		// First, add the necesary CSS and scripts.

		// NOTE: OnRendering is the best place to call Util.HtmlHead.* methods to add scripts & css.
		// This ensures that your css/js assets are available *before* the control is dumped
		// and keeps your control self-contained. The Util.HtmlHead.* methods are idempotent,
		// so even if multiple controls are dumped the script/css is injected only once.

		Util.HtmlHead.AddCssLink ("https://unpkg.com/leaflet@1.9.4/dist/leaflet.css");
		Util.HtmlHead.AddScriptFromUri ("https://unpkg.com/leaflet@1.9.4/dist/leaflet.js");

		Util.HtmlHead.AddScript ("""
			function InitLeafletMap(el, lat, lng, zoom, addMarker) {
				el._map = L.map(el).setView([lat, lng], zoom);
				L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(el._map);
				if (addMarker) L.marker([lat, lng]).addTo(el._map);
				el._map.on('contextmenu', function(event) {
					const loc = event.latlng.lat + ', ' + event.latlng.lng;
					el.dispatchEvent(new CustomEvent('rightClick', { detail: loc }));
				});
			}
			function UpdateLeafletMap(el, lat, lng, zoom) {
				if (el._map) el._map.setView([lat, lng], zoom);
			}
			""");

		// Handle the custom right-click event on the C# side:
		HtmlElement.AddEventListener ("rightClick",
			["detail"],
			(sender, args) => RightClick?.Invoke (this, args.Properties ["detail"]));

		base.OnRendering (e);
	}

	// The OnReady method fires *after* the control has been dumped.
	// From here, you can safely invoke JavaScript by calling HtmlElement.Run or HtmlElement.Eval.
	protected override void OnReady (EventArgs e)
	{
		// Call the InitLeafletMap JavaScript function we defined earlier using HtmlElement.Run().
		// (JsonEncodeArgs is a static helper method in Control that formats interpolated arguments using JsonSerializer.Serialize.)
		HtmlElement.Run (JsonEncodeArgs ($"InitLeafletMap(targetElement, {Latitude}, {Longitude}, {Zoom}, {ShowMarker.ToString().ToLower()});"));
		
		base.OnReady (e);
	}

	void Update()
	{
		// Without the IsReady check, we could end up calling HtmlElement.Run multiple times before 
		// the control has been dumped (all of which will queue up) - inefficient!
		if (IsReady)
			HtmlElement.Run (JsonEncodeArgs ($"UpdateLeafletMap(targetElement, {Latitude}, {Longitude}, {Zoom}, {ShowMarker.ToString().ToLower()});"));
	}
}
