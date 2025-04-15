// LINQPad Statements

using System.Dynamic

// To export data to HTML, use Util.ToHtmlString:

var data = TimeZoneInfo.GetSystemTimeZones();

string html = Util.ToHtmlString (data);

// Render the HTML using an iFrame:
new LINQPad.Controls.IFrame (html, "50%", "20em").Dump ("Complete HTML document, rendered in iFrame");

// Util.ToHtmlString has additional overloads for including multiple objects and
// specifying a maximum depth. You can also emit just an HTML fragment.

string htmlFragment = Util.ToHtmlString (true, 3, true, data.First());
htmlFragment.Dump ("HTML Fragment");
Util.RawHtml (htmlFragment).Dump ("HTML fragment - rendered");

// Another approach is is call Util.CreateXhtmlWriter:

using var writer = Util.CreateXhtmlWriter (true);
writer.WriteLine ("Hello, world");
writer.WriteLine (data);
string htmlResult = writer.ToString();


