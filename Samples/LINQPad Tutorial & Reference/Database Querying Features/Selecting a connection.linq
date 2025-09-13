<Query Kind="Expression" />

/* There are several ways to tell a script to use a connection.

!!The easiest is simply to drag the desired database from the Schema Explorer TreeView to the code editor!!

Here are the other ways:
	Drag any database object from the Schema Explorer to the editor
	Use the 'Connection' dropdown box above the editor
	Right-click the connection => Use in Current Script
	Press Ctrl+Shift+D - this sets the connection to whatever's currently selected in the Schema Explorer
	Use the hyperink right of the connection dropdown above the editor.

You can also press Ctrl+Shift+N on an existing script to create a new script with the same connection.

The shortcut to clear a script's connection is Ctrl+Shift+D / Command-Shift-D.

ADVANCED: CROSS-DATABASE QUERYING
=================================

To query multiple SQL databases at once (LINQPad Premium Users):
	Ctrl+Drag additional connection(s) from Schema Explorer to the editor (Shift+Drag on macOS)
	
You can also specify multiple databases in the connection properties dialog.
	1. Add a new LINQ-to-SQL connection.
	2. Choose 'Specify New or Existing Database' and choose the primary database that you want to query.
	3. Click 'Include Additional Databases' and pick the extra database(s) you want to include.
	   You can also choose databases from linked servers in this dialog.
	
Note that cross-database querying works only with LINQ-to-SQL connections.

*/