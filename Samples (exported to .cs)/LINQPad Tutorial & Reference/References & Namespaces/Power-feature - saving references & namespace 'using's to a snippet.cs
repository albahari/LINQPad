// LINQPad Expression

#r: "nuget: Newtonsoft.Json"

using Newtonsoft.Json;

/* 
	If you have a Developer/Premium license, you can easily save your current references and namespaces (and other 
	properties) to a snippet and then recall that snippet whenever you want - with just a few keystrokes.

	This script includes the Json.NET NuGet reference and the Newtonsoft.Json namespace.
	Press F4, and click 'Save as snippet'. Save it to a simple name such as 'json'.
	
	Then, create a new script with Ctrl+N / Command-N and type num followed by the TAB key. Your references/namespaces
	will be instantly added to the new script.
	
	This feature is particularly useful when you have a big set of references or namespaces (e.g., WPF development). */

JsonConvert.SerializeObject (new { X = 123, Y = 234 })