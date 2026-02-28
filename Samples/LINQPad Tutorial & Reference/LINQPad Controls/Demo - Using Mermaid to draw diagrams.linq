<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// This sample uses the Mermaid library to draw diagrams.

string definition = """
	flowchart TD
	    A[User] -->|Clicks| B[Button]
	    B --> C{Valid?}
	    C -- Yes --> D[Render Diagram]
	    C -- No  --> E[Show Error]
	""";

var mermaid = new MermaidControl (definition, "500px");

var editor = new TextArea (definition) { Rows = 20, Cols = 60 }.AddStyle ("font-family", "monospace");
editor.TextInput += (s, e) => mermaid.Definition = editor.Text;

new FlexBox ("row", "1em", "wrap",
	new FlexBox ("column", ".3em",
		editor,
		new Button ("Save SVG", b => mermaid.SaveSvg())),
	mermaid
).Dump();

// Custom control to encapsulate the mermaid.js library.
// AI can write these for you - press Ctrl+I or Command-I.
class MermaidControl : Control
{
	string _definition;

	public string Definition
	{
		get => _definition;
		set { _definition = value; UpdateDiagram(); }
	}

	public MermaidControl (string definition = "", string width = null, string height = null) : base ("div")
	{
		_definition = definition;
		if (width != null) Styles ["width"] = width;
		if (height != null) Styles ["height"] = height;
	}

	// Fires just *before* the control is dumped
	protected override void OnRendering (EventArgs e)
	{
		// Define the necessary scripts. Note that calls to to Util.HtmlHead.* are idempotent
		// (scripts/CSS is injected only once, no matter how many calls you make).
		
		Util.HtmlHead.AddScriptFromUri ("https://cdn.jsdelivr.net/npm/mermaid/dist/mermaid.min.js");

		Util.HtmlHead.AddScript ("""
			async function RenderMermaid(el, themeName) {
				try {
					mermaid.initialize({ startOnLoad: false, theme: themeName, suppressErrorRendering: true });
					const pre = el.querySelector('.mermaid');
					if (!pre) return;
					await mermaid.run({ nodes: [pre] });
				} catch(err) {
					el.innerHTML = '<pre style="color:red;">' + err.message + '</pre>';
				}
			}
			function SaveMermaidSvg(el) {
				const svg = el.querySelector('svg');
				if (!svg) { external.log('No diagram to save'); return; }
				const blob = new Blob([svg.outerHTML], { type: 'image/svg+xml' });
				const url = URL.createObjectURL(blob);
				const a = document.createElement('a');
				a.href = url; a.download = 'diagram.svg'; a.click();
			}
			""");

		base.OnRendering (e);
	}

	// Fires *after* the control is dumped. You can safely invoke JavaScript from here.
	protected override void OnReady (EventArgs e)
	{
		Util.ThemeChanged += (sender, args) => UpdateDiagram();
		UpdateDiagram();		
		base.OnReady (e);
	}

	void UpdateDiagram()
	{
		// Without this check, we could end up calling HtmlElement.Run multiple times before 
		// the control has been dumped, which is inefficient.
		if (!IsReady) return;
		
		HtmlElement.InnerHtml = $"<pre class='mermaid'>{_definition}</pre>";
		HtmlElement.Run ($"RenderMermaid(targetElement, '{(Util.IsDarkThemeEnabled ? "dark" : "light")}');");
	}

	public void SaveSvg()
	{
		if (!IsReady) return;
		HtmlElement.Run ("SaveMermaidSvg(targetElement);");
	}
}
