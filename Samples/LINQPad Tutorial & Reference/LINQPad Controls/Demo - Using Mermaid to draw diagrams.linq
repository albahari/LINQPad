<Query Kind="Statements">
  <Connection>
    <ID>7855b4d6-efcd-4ded-9669-1800e77afdea</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Server>tcp:g3ztr3nte0.database.windows.net</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>main</Database>
    <UserName>joe@albahari.com</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAVXQi0EyUG06fNrubeRJ4YAAAAAACAAAAAAAQZgAAAAEAACAAAADDnKomo7jM+Pw1C5XMx2rGF8At0BeWCDbpWLND4yKobAAAAAAOgAAAAAIAACAAAADtYG3n4o+NXNi29n6zSE6gXgzF2gZ/JhXdnjyGW9LppxAAAAD04T5fxTk33rk9MqG4F9njQAAAAPKfzhrNEc1Q8BYcWiUN1HDos4gCpTJWo7KNCmL7hY7LDEnaNgUPkUJm9QxhjhD+VV7tWCZWfYOXoq9Kcb7iyDI=</Password>
    <DbVersion>Azure</DbVersion>
    <DisplayName>Licensing database</DisplayName>
    <UniversalAuthentication>true</UniversalAuthentication>
    <Persist>true</Persist>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <Namespace>LINQPad.Controls</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// This sample uses the Mermaid library to draw diagrams.

// Load Mermaid.
Util.HtmlHead.AddScriptFromUri ("https://cdn.jsdelivr.net/npm/mermaid/dist/mermaid.min.js");

// Add a function to render all .mermaid blocks.
Util.HtmlHead.AddScript ("""
	window.renderAllMermaid = async function(themeName) {
	  if (!window._mermaidInitialized != themeName) {
	    mermaid.initialize({ startOnLoad: false, theme: themeName });
	    window._mermaidInitialized = themeName;
	  }
	  await mermaid.run({ querySelector: '.mermaid' });
	};
	""");

// Define a function for saving the mermaid content to svg format.
Util.HtmlHead.AddScript ("""
	window.saveMermaidAsSvg = function() {
	  const svg = document.querySelector('.mermaid svg');
	  if (!svg) { external.log('No diagram to save'); return; }
	  const svgData = svg.outerHTML;
	  const blob = new Blob([svgData], { type: 'image/svg+xml' });
	  const url = URL.createObjectURL(blob);
	  const a = document.createElement('a');
	  a.href = url; a.download = 'diagram.svg'; a.click();
	};
	""");

var mermaidHost = new Div();
mermaidHost.Styles ["width"] = "500px";

var editor = new TextArea (Samples.FlowChart);
editor.Rows = 20;
editor.Styles ["font-family"] = "consolas,monospace";
editor.TextInput += (s, e) => Render();
Util.ThemeChanged += (sender, args) => Render();

var buttons = new WrapPanel (".5em",

	new Button ("Sample: Flowchart", b => UpdateMermaid (Samples.FlowChart)),
	new Button ("Sample: Sequence", b => UpdateMermaid (Samples.Sequence)),
	new Button ("Sample: Class", b => UpdateMermaid (Samples.Class)),
	new Button ("Save SVG", b => Util.JS.RunFunction ("saveMermaidAsSvg"))
);

Util.HorizontalRun (true,
	Util.VerticalRun ("Mermaid:", editor, buttons),
	mermaidHost).Dump();
	
Render();

void Render()
{
	mermaidHost.HtmlElement.InnerHtml = $"<pre class='mermaid'>{editor.Text}</pre>";
	
	// Call renderAllMermaid to tell Mermaid to render
	Util.JS.RunFunction ("renderAllMermaid", Util.IsDarkThemeEnabled ? "dark" : "light");
}

void UpdateMermaid (string text)
{
	editor.Text = text;
	Render();
}

class Samples
{
	public const string
		FlowChart = """
			flowchart TD
			    A[User] -->|Clicks| B[Button]
			    B --> C{Valid?}
			    C -- Yes --> D[Render Diagram]
			    C -- No  --> E[Show Error]
			""",

		Sequence = """
			sequenceDiagram
			    participant A as Alice
			    participant B as Bob
			    A->>B: Hello Bob, how are you?
			    B-->>A: I am good thanks!
			""",

		Class = """
			classDiagram
			    class Animal {
			      +String name
			      +int age
			      +void eat()
			    }
			    class Dog {
			      +void bark()
			    }
			    Animal <|-- Dog
			""";
}