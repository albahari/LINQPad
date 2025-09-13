// LINQPad Statements

#LINQPad admin

using System.Security.Principal;

// Sometimes it's useful to run the current script with administrative elevation in Windows.
// To to so, add the following directive to the top of your script:



RunningAsAdmin().Dump ("Is an admin");

bool RunningAsAdmin() => new WindowsPrincipal (WindowsIdentity.GetCurrent()).IsInRole (WindowsBuiltInRole.Administrator);