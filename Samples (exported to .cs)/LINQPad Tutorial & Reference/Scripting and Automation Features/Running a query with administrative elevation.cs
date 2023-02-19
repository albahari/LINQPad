// LINQPad Statements

#LINQPad admin

using System.Security.Principal

// Sometimes it's useful to run the current query with administrative elevation.
// To to so, add the following directive to the top of your query:



RunningAsAdmin().Dump ("Is an admin");

bool RunningAsAdmin() => new WindowsPrincipal (WindowsIdentity.GetCurrent()).IsInRole (WindowsBuiltInRole.Administrator);