// LINQPad Statements

using LINQPad.Controls;
using System.Globalization;

"Search:".Dump();
var searchBox = new TextBox().Dump();

var dc = new DumpContainer().Dump();
searchBox.TextInput += (sender, args) => Update();
Update();
searchBox.Focus();

void Update()
{
	// Assign searchBox.Text to a temporary variable to avoid excessive round-tripping to the browser.
	string searchExpr = searchBox.Text;
	
	dc.Content =
		from c in CultureInfo.GetCultures (CultureTypes.AllCultures)
		where $"{c.DisplayName} {c.Name}".IndexOf (searchExpr, StringComparison.OrdinalIgnoreCase) > -1
		select new { c.Name, c.DisplayName, c.IsNeutralCulture, c.LCID, c.KeyboardLayoutId };
}


