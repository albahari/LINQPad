<Query Kind="Statements">
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
</Query>

// To dump markdown, call Util.Markdown:

string markdown = """
	# Dumping markdown
	
	To dump **markdown**, call `Util.Markdown`:
	
	```
	Util.Markdown ("**bold**").Dump();
	```
	
	## Tables are supported

	| Syntax | Description |
	|--------|-------------|
	| `|` | Column separator |
	| `---` | Header separator |
	
	""";
	
Util.Markdown (markdown).Dump();

// To convert markdown to HTML, use the Html property:
Util.Markdown (markdown).Html.Dump ("HTML");

// Util.Mardown returns an interactive LINQPad control (LINQPad.Controls.MarkdownViewer) that can be subsequently updated.
//  - see script://../../LINQPad_Controls

// Util.Markdown doesn't support Latex. For that, use Util.Latex or LINQPad.Controls.LatexViewer.