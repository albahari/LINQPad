<Query Kind="Statements" />

/* If you go to Query Properties (F4) and click the 'Advanced' tab, you'll see the following checkboxes.

'Copy all non-framework references to a single folder'
	This ensure that all referenced assembly files are physically copied to a single output folder.
	At the expense of a little extra file I/O, it allows things such as MEF to work, which examines
	the executing assembly's folder for other assemblies to dynamically load.
	
'Disable My Extensions'
	The 'My Extensions' query (in My Queries, bottom-left), lets you write classes and methods that are
	accessible to all queries. This checkbox lets you create a self-contained query that you can share
	without the compiler complaining that you've defined the same types twice.

*/