<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// More controls...

new PasswordBox ().Dump ("Enter a Password");

new FilePicker ().Dump ("Pick a file...");

var range = new RangeControl (1, 100, 50) { Width = "40em"}.Dump ("Range control");
