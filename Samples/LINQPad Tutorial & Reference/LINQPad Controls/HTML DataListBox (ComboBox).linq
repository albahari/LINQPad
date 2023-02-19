<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

string[] colors = { "Red", "Green", "Violet", "Blue", "Orange", "Yellow" };

// There's also a DataListBox, which is a TextBox with an HTML DataList (rather like a ComboBox)

new DataListBox (colors).Dump();