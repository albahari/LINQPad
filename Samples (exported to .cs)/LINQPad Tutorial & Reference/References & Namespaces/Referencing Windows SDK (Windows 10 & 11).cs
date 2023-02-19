// LINQPad Statements

// You can consume the Windows 10 SDK libraries for Windows 10 and 11 by ticking the checkbox
// in the Query Properties dialog (F4) at the bottom right.
//
// (LINQPad implements this referencing the Microsoft.Windows.SDK.NET.Ref NuGet package,
//  choosing a version appropriate to whatever version of Windows 10 or 11 you are running).

Windows.Devices.Input.PointerDevice.GetPointerDevices().Dump ("Pointer devices");

var wifiAdapters = await Windows.Devices.WiFi.WiFiAdapter.FindAllAdaptersAsync();
wifiAdapters.Dump ("Wifi adapters");

