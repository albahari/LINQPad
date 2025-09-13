// LINQPad Statements

using System.Net;
using System.Net.Http;

// You can dump images either via by calling Util.Image, or by dumping a Bitmap:

Util.Image ("https://www.linqpad.net/images/LINQPad.png").Dump ("from URI");

byte[] imageBlob = await new HttpClient().GetByteArrayAsync ("https://www.linqpad.net/images/LINQPad.png");
Util.Image (imageBlob).Dump ("from byte[]");

#if WINDOWS
new System.Drawing.Bitmap (new MemoryStream (imageBlob)).Dump ("from System.Drawing.Image");
#endif

// You can optionally specify a size in which to render the image as follows:

Util.Image ("https://www.linqpad.net/images/LINQPad.png", Util.ScaleMode.ResizeTo (100)).Dump ("100 pixels wide");

#if WINDOWS
new System.Drawing.Bitmap (new MemoryStream (imageBlob)).Dump (Util.ScaleMode.ResizeTo (50, 70), "50x70");
#endif

// You can get more control and interactivity by instantiating a LINQPad.Controls.Image - see script://../../LINQPad_Controls
