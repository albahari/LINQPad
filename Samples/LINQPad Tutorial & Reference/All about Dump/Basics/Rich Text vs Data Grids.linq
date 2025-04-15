<Query Kind="Expression">
  <Output>DataGrids</Output>
  <Namespace>System.Globalization</Namespace>
</Query>

// You can dump to data grids either by clicking the toolbar button above, or by calling Dump(true).
// Try running the query below in each mode to compare the results:

CultureInfo.GetCultures (CultureTypes.NeutralCultures)

// With data grids, sub-objects are no longer rendered inline, and some Dump features are disabled.
//
// However, you can:
//  - see any number of rows (limited only by memory)
//  - click headers to sort data (and type into the columns for incremental search)
//  - re-order columns with Alt+Click
//  - freeze columns (right-click)
//  - display private fields/properties (right-click)
//  - make a rectangular selection and export to CSV/HTML/Excel
//
// Also, if you have a developer/premium license, you can edit output from LINQ-to-SQL and EF Core queries
// and save changes back to the database.