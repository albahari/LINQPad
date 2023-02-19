<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

// To display data side-by-side, use Util.HorizontalRun:

Util.HorizontalRun (true, "ABCDEF".ToCharArray(), "123456".ToCharArray()).Dump ("Side-by-side");

// You can feed a limitless number of objects into Util.HorizontalRun:

var cultures = 
	from c in CultureInfo.GetCultures (CultureTypes.AllCultures).Take (10)
	select new { c.Name, c.DisplayName, c.LCID, c.KeyboardLayoutId };
	
Util.HorizontalRun (true, cultures).Dump ("First 10 cultures");