// LINQPad Program

// All scripts automatically reference the 'My Extensions' script (bottom of 'My Scripts' TreeView).
// 'My Extensions' is a great place to write general-purpose extension methods and utility classes.

// For instance, suppose you want to define an "ArrayOfOne" method that wraps an object in an array.
// While the following works, it works only for the current script:

void Main()
{
	"Test".ArrayOfOne().Dump();
}

public static class MyExtensions
{
	public static T[] ArrayOfOne<T> (this T item) => new T[] { item };
}

// Now try cutting the method definition from the class above, and pasting it into the 'My Extensions' script.
// That extension method will now work for all scripts.

// TIP: If you have a paid LINQPad edition, pressing F12 over a method call will jump to its definition.
//      This jumps into 'My Extensions', too.
//
// TIP: You can navigate directly to 'My Extensions' via the hotkey on the File menu.
//
// TIP: You can disable 'My Extensions' for a particular script via the checkbox in Script Properties (F4, Advanced)
//      or by pressing Alt+Shift+Y / Option-Command-Y. This is sometimes useful in avoiding conflicts.