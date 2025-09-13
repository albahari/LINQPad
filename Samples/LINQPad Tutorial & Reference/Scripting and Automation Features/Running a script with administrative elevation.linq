<Query Kind="Statements">
  <Namespace>System.Security.Principal</Namespace>
</Query>

// Sometimes it's useful to run the current script with administrative elevation in Windows.
// To to so, add the following directive to the top of your script:

#LINQPad admin

RunningAsAdmin().Dump ("Is an admin");

bool RunningAsAdmin() => new WindowsPrincipal (WindowsIdentity.GetCurrent()).IsInRole (WindowsBuiltInRole.Administrator);