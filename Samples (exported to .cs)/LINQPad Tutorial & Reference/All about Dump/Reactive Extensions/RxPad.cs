// LINQPad Program

#r: "nuget: System.Reactive"

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

// This sample, by Erik Meijer, displays a pad that you can draw on - with Rx!
// This works in LINQPad because you can dump any Windows Forms or WPF control, and it will render.

void Main()
{
	var pen = new Pen(Color.Navy, 2);
	var box = new PictureBox();
	
	var mouseMoves = box.GetMouseMoves().Select (m => m.Location);
	var mouseDiffs = mouseMoves.Buffer(2,1);	
	var mouseUpDowns = box.GetMouseDowns().Select (m => true).Merge (box.GetMouseUps().Select (m => false));
	
	Graphics graphics = null;
	box.SizeChanged += delegate
	{
		box.Image = new Bitmap (box.Width, box.Height);
		graphics = Graphics.FromImage (box.Image);
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		graphics.DrawString ("Rx Pad", new Font ("Verdana", 150, FontStyle.Bold), SystemBrushes.ControlLight, 10, 10);
	};
	
	var drag = mouseUpDowns
			.Select(down => down ? mouseDiffs : Observable.Never<IList<Point>>())
			.Switch();
	
	drag.Subscribe(ps =>
	{
		graphics.DrawLine(pen, ps[0], ps[1]);
		box.Invalidate(); 
	});
	
	box.Dump ("Paint!");
}

public static class MyExtensions
{
	public static IObservable<MouseEventArgs> GetMouseMoves (this Control c)
		=> Observable.FromEventPattern<MouseEventArgs> (c, "MouseMove").Select (m => m.EventArgs);
		
	public static IObservable<MouseEventArgs> GetMouseUps (this Control c)
		=> Observable.FromEventPattern<MouseEventArgs> (c, "MouseUp").Select (m => m.EventArgs);

	public static IObservable<MouseEventArgs> GetMouseDowns (this Control c)
		=> Observable.FromEventPattern<MouseEventArgs> (c, "MouseDown").Select (m => m.EventArgs);
}