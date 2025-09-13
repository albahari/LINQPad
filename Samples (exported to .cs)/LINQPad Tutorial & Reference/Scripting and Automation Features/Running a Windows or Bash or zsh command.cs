// LINQPad Statements

// Under Windows, Util.Cmd also runs operating system commands and batch files:

if (OperatingSystem.IsWindows())
	Util.Cmd ("dir", "/od");

// Under macOS, use Util.Bash or Util.Zsh to execute a Bash/zsh command

Util.Zsh ("ls -l ~");
Util.Bash ("echo hello");

// For executing bash/zsh script files, call Util.BashScript or Util.ZshScript.

// Util.BashScript ("scriptfile.bash");


