<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// Here are some checkboxes:

var chk1 = new CheckBox ("Include Tables", false, c => c.Checked.Dump()).Dump();
var chk2 = new CheckBox ("Include Views",  false, c => c.Checked.Dump()).Dump();

// Radio buttons are similar, except you also specify a group (only one in the same group can be checked):

var radio1 = new RadioButton ("group1", "Option 1").Dump();
var radio2 = new RadioButton ("group1", "Option 2").Dump();
var radio3 = new RadioButton ("group1", "Option 3").Dump();

// To lay them out horizontally rather than vertically, dump them inside a Div, WrapPanel 
// or StackPanel - see query://Grouping_controls_(HTML_fieldset)