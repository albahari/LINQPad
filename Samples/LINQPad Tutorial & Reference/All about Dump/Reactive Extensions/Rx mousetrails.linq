<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Input</Namespace>
  <Namespace>System.Windows.Media</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

// This example uses WPF. Move the mouse through the results window after running the script.

void Main()
{
	var text = "skcoR snoisnetxE evitcaeR";
	
	Label[] labels = text.Select (t => new Label { Content = t.ToString(), FontSize=20 }).ToArray();
	
	var canvas = new Canvas { Background = Brushes.AliceBlue }.Dump ("Reactive Mousetrails");
	foreach (var label in labels) canvas.Children.Add (label);
	
	var mouseMoves = canvas.GetMouseMoves().Select (args => args.GetPosition (canvas));
	
	var syncContext = DispatcherSynchronizationContext.Current;
	
	int delay = 0;
	foreach (var label in labels)
		mouseMoves
			.Delay (TimeSpan.FromMilliseconds (delay++ * 50))
			.ObserveOn (syncContext)
			.Subscribe (point => label.SetCanvasPosition (point));
}

public static class MyExtensions
{
	public static IObservable<MouseEventArgs> GetMouseMoves (this UIElement e)
		=> Observable.FromEventPattern<MouseEventArgs> (e, "MouseMove").Select (m => m.EventArgs);
	
	public static void SetCanvasPosition (this UIElement e, Point p)
	{
		e.SetValue (Canvas.LeftProperty, p.X);
		e.SetValue (Canvas.TopProperty, p.Y);
	}
}