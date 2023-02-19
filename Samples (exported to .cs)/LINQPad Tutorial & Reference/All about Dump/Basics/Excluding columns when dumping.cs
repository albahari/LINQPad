// LINQPad Statements

using System.Globalization

// Use the 'exclude' parameter to exclude columns:

CultureInfo.GetCultures(CultureTypes.AllCultures).Take(5).Dump (exclude:"Calendar, CompareInfo, OptionalCalendars, Parent");

// This works in both rich text and data grid mode.

// There's a similar 'include' option to include only specified columns.