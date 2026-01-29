<Query Kind="SQL">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
  <Namespace>System.Net</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

/* LINQPad includes a special AI tool to perform a deep conversion from SQL to LINQ.

The tool automatically provides the model with the schema information it needs,
along with numerous guidelines to ensure to ensure a quality conversion.
It supports SQL Server, SQLite, PostgreSQL, MySQL and Oracle with EF Core,
and SQL Server with LINQ-to-SQL.

The tool also lets you run the SQL and LINQ queries side-by-side to compare results.

Demo: Select the following SQL and press Ctrl+Shift+L or Command-Shift-L.

TIP: Choose a high-end model for the best results.   */

WITH ArtistStats AS (
    SELECT 
        ar.ArtistId,
        ar.Name AS ArtistName,
        COUNT(DISTINCT al.AlbumId) AS AlbumCount,
        COUNT(t.TrackId) AS TotalTracks,
        ROUND(SUM(t.Milliseconds) / 60000.0, 2) AS TotalMinutes
    FROM Artist ar
    LEFT JOIN Album al ON ar.ArtistId = al.ArtistId
    LEFT JOIN Track t ON al.AlbumId = t.AlbumId
    GROUP BY ar.ArtistId, ar.Name
)
SELECT * FROM ArtistStats
WHERE AlbumCount > 0
ORDER BY TotalTracks DESC, AlbumCount DESC