// LINQPad Statements

using LINQPad.Controls;
using System.Net;

// The Image control offers the same functionality as Util.Image, but with interactivity.

var img = new Image ("https://www.linqpad.net/images/LINQPad.png").Dump ("from URI");
img.Click += (sender, args) => img.Width += 10;

// You can also create an image from a filename, System.Drawing.Image, and byte array.

// There's also a Video control for displaying video files or URLs:
new Video ("https://publicdomainmovie.net/movie.php?id=sherlockjr1924_201909&type=.mp4", autoPlay:true).Dump ("Video");

// (For displaying YouTube videos, use an IFrame - see preceding example.)