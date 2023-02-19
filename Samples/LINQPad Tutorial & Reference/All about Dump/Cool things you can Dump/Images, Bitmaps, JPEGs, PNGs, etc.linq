<Query Kind="Statements">
  <Namespace>System.Net</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

// You can dump images either via by calling Util.Image, or by dumping a Bitmap:

Util.Image ("http://www.linqpad.net/images/LINQPad.png").Dump ("from URI");

byte[] imageBlob = new WebClient().DownloadData ("http://www.linqpad.net/images/LINQPad.png");
Util.Image (imageBlob).Dump ("from byte[]");

new System.Drawing.Bitmap (new MemoryStream (imageBlob)).Dump ("from System.Drawing.Image");

// You can optionally specify a size in which to render the image as follows:

Util.Image ("http://www.linqpad.net/images/LINQPad.png", Util.ScaleMode.ResizeTo (100)).Dump ("100 pixels wide");
new System.Drawing.Bitmap (new MemoryStream (imageBlob)).Dump (Util.ScaleMode.ResizeTo (50, 70), "50x70");

// You can get more control and interactivity by instantiating a LINQPad.Controls.Image - see query://../../LINQPad_Controls
