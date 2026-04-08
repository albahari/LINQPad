// LINQPad Statements

using LINQPad.Controls;

// A PasswordBox emits an <input type="password">
new PasswordBox ().Dump ("Enter a Password");

// A RangeControl emits an <input type="range"> and exposes a ValueInput event.
var range = new RangeControl (1, 100, 50) { Width = "40em"}.Dump ("Range control");
range.ValueInput += (sender, args) => range.Value.Dump();

// More controls:
new FilePicker ().Dump ("Pick a file...");