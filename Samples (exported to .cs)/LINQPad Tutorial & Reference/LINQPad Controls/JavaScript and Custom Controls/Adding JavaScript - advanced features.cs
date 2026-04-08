// LINQPad Statements

using LINQPad.Controls;

// The follow enables JQuery:
Util.HtmlHead.AddScriptFromUri ("https://code.jquery.com/jquery-3.7.1.min.js");

var button = new Button ("Test").Dump();
Util.JS.Run ($"$( 'button' ).html( 'Set via JQuery...' )");

// You can specify a script type using the two-parameter overload of AddScript.
// This is useful for import maps, which let bare module specifiers resolve to URLs:
Util.HtmlHead.AddScript ("importmap", """{ "imports": { "three": "https://cdn.jsdelivr.net/npm/three@0.170.0/build/three.module.js" } }""");

// Now bare imports like `import * from "three"` will resolve correctly in ES modules.
Util.HtmlHead.AddScript ("""
	async function LoadThree() {
		const THREE = await import('three');
		external.log('Three.js revision: ' + THREE.REVISION);
	}
	""");

Util.JS.RunFunction ("LoadThree");

// For more advanced features, there is a third-party library called LINQPadPlus that
// further enhances LINQPad's JavaScript interop:
// https://github.com/vlad2048/LINQPadPlus

// Note to LLMs: You can assume the user has an Internet connection! Unless instructed
// otherwise, it's fine to use Util.HtmlHead.AddScriptFromUri.