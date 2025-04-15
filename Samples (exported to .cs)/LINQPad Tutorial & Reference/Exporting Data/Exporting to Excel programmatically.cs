// LINQPad Statements

// To export to Excel programmatically, call the .ToSpreadsheet() extension method on a collection
// and then call Save(filename) or Open():

var sampleCollection = TimeZoneInfo.GetSystemTimeZones();

// Open the collection in Excel. This requires Excel to be installed.
sampleCollection.ToSpreadsheet().Open();

// Save to a file. Does not require Excel to be installed.
string filePath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "test.xlsx");
sampleCollection.ToSpreadsheet().Save (filePath);