// LINQPad Statements

using LINQPad.Controls;

var yourChoice = new DumpContainer();
string[] colors = { "Red", "Green", "Violet", "Blue", "Orange", "Yellow" };

// Dropdown-style select box:
var selectBox = new SelectBox (colors, 0,
	sb => yourChoice.Content = sb.SelectedOption
	).Dump ("Choose a color");

// ListBox:
var listBox = new SelectBox (SelectBoxKind.ListBox, colors, 0,
	lb => yourChoice.Content = lb.SelectedOption
	).Dump ("Listbox");

// Multi-select ListBox:
var multi = new SelectBox (SelectBoxKind.MultiSelectListBox, colors, 0,
	sb => yourChoice.Content = sb.SelectedOptions
	).Dump ("Multi-select Listbox");

yourChoice.Dump ("Your choice(s)");