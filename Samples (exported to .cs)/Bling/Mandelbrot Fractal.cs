// LINQPad Program

#LINQPad optimize+

using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

// This renders the Mandelbrot fractal, leveraging data parallelism.
// Left-click to zoom in; right-click to zoom out; middle-click to reset.

// Enable compiler optimizations

readonly Rect _initialBounds = new Rect (-2, -1.2, 2.5, 2.4);
readonly Stack<Rect> _zoomHistory = new Stack<Rect>();
readonly PictureBox _pictureBox = new PictureBox();

Frame _frame;
CancellationTokenSource _canceler = new CancellationTokenSource();

async Task Main()
{
	var setBounds = _initialBounds;		
	
	_pictureBox.SizeChanged += (sender, args) => RenderToScreen (setBounds);   // Re-render when resized
	
	_pictureBox.Disposed += (sender, args) => _canceler.Cancel();              // In case you close the output panel
	
	_pictureBox.MouseDown += (sender, args) =>
	{
		if (args.Button == MouseButtons.Left) _zoomHistory.Push (setBounds);
		if (args.Button == MouseButtons.Middle) _zoomHistory.Clear();
		
		setBounds = 
			args.Button == MouseButtons.Left ? _frame.GetZoomRect (args.Location.X, args.Location.Y) :			
			_zoomHistory.Any() ? _zoomHistory.Pop() :
			_initialBounds;

		RenderToScreen (setBounds.Dump ($"You zoomed to:"));
		Util.RawHtml ($"Magnification: ~10<sup>{Math.Round (Math.Log10 (2.4 / setBounds.Height), 0)}</sup>").Dump();
	};
	
	// Dump the Windows Forms PictureBox to render it to the output panel:
	_pictureBox.Dump ("Mandelbrot");	
	
	// This line is optional: it keeps query running so you can click 'Cancel' to stop the current render without clearing
	// the image. It also keeps the debugger alive (if you comment the '#LINQPad optimize' directive out of the query).
	await Task.Delay (Timeout.Infinite, QueryCancelToken);
}

async void RenderToScreen (Rect setBounds)
{	
	// Cancel any existing render and start a new one.
	_canceler.Cancel();
	
	// The user can cancel the render in two ways: by clicking 'Cancel' or by clicking on a new point
	// before the previous image has finished rendering.
	var canceler = _canceler = CancellationTokenSource.CreateLinkedTokenSource (QueryCancelToken);
	
	var frame = _frame = new Frame (setBounds, _pictureBox.Width, _pictureBox.Height, canceler.Token);
	var renderTask = Task.Run (frame.Render);	
	
	while (!canceler.IsCancellationRequested)   // Update the image every 100ms.
	{
		if (_pictureBox.Image != null) _pictureBox.Image.Dispose();
		bool completed = renderTask.IsCompleted;
		_pictureBox.Image = frame.GetImage();
		if (completed) return;
		await Task.Delay (100);
	};
}

public class Frame
{
	public readonly Rect SetBounds;
	public readonly int RenderWidth, RenderHeight;
	CancellationToken _cancelToken;

	uint [] _pixels;
	
	public Frame (Rect setBounds, int renderWidth, int renderHeight, CancellationToken cancelToken)
	{
		SetBounds = setBounds;
		RenderWidth = renderWidth;
		RenderHeight = renderHeight;
		_cancelToken = cancelToken;
		_pixels = new uint [renderWidth * renderHeight];
	}

	public void Render ()
	{
		int maxCycles = 500;
		if (SetBounds.Width < 1) maxCycles = Convert.ToInt32 (Math.Log10 (1 / SetBounds.Width) * 5000);

		Action<int> lineCalculator = yPixel =>
		{
			if (_cancelToken.IsCancellationRequested) return;
			double y = SetBounds.Height * yPixel / RenderHeight + SetBounds.Y;
			for (int xPixel = 0; xPixel < RenderWidth; xPixel++)
			{
				double x = SetBounds.Width * xPixel / RenderWidth + SetBounds.X;
				_pixels [xPixel + yPixel * RenderWidth] = CalculateColor (x, y, maxCycles);
			}
		};

		Parallel.For (0, RenderHeight, 
			new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 },  // Leave some CPU for the GUI
			lineCalculator);
	}

	static uint CalculateColor (double x, double y, int maxCycles)
	{
		int iteration = 0;
		double xx = x, yy = y;
		while (xx * xx + yy * yy <= 4)
		{
			if (iteration++ > maxCycles) return 0xFF000000;
			double temp = xx * xx - yy * yy + x;
			yy = 2 * xx * yy + y;
			xx = temp;
		}

		return (uint)(_colors [iteration % _colors.Length] + 0xFF000000);
	}

	public unsafe System.Drawing.Image GetImage ()
	{
		fixed (void* b = _pixels)
		{
			var ptr = new IntPtr (b);
			return new System.Drawing.Bitmap (RenderWidth, RenderHeight, 4 * RenderWidth,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb, ptr);
		}
	}

	public Rect GetZoomRect (int centrePixelX, int centrePixelY)
	{
		double centreSetX = SetBounds.Width * centrePixelX / RenderWidth + SetBounds.X;
		double centreSetY = SetBounds.Height * centrePixelY / RenderHeight + SetBounds.Y;

		double newWidth = SetBounds.Width / 4;
		double newHeight = newWidth * RenderHeight / RenderWidth;

		return new Rect (
			centreSetX - newWidth / 2,
			centreSetY - newHeight / 2,
			newWidth, newHeight);
	}	

	static int [] _colors =
		Enumerable.Range (0, 6).Select (i => i * 20 + 135).Concat (
		Enumerable.Range (0, 8).Select (i => (i * 30 + 10) * 256 + (7 - i) * 10 + 155)).Concat (
		Enumerable.Range (0, 6).Select (i => ((5 - i) * 30 + 90) * 256)).Concat (
		Enumerable.Range (0, 4).Select (i => ((3 - i) * 30) * 256 + i * 40))
		.ToArray ();
}