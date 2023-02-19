// LINQPad Statements

using LINQPad.Controls

// An iFrame lets you dump an entire HTML document.

// (To dump a [static] HTML fragment, use a Literal control or Util.RawHtml.
//  To dump a dynamic HTML fragment, use a Span or Div control - see query://Simple_HTML_controls_-_div_and_span ).

var completeHtml = @"<!doctype html>
<html lang=""en"">
  <head>
    <meta charset=""utf-8"">
    <title></title>
  </head>
  <body>
    <p>HTML Line 1</p>
	<p><b>HTML Line 2</b></p>
  </body>
</html>";

// Display a iFrame from an HTML string:
new IFrame (completeHtml, autoSize:true).Dump ("iframe - html");

// Display an embedded YouTube video:
new IFrame (new Uri ("https://www.youtube.com/embed/mLX1sYVf-Xg")).Dump ("iframe - web page");
