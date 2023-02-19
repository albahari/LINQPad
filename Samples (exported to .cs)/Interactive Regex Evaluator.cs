// LINQPad Program

using LINQPad.Controls

/****************************************************************************************
                           INTERACTIVE REGEX EVALUATOR
	
	           Run this query to experiment with Regular Expressions!
	
  You can also use the source code as a model for creating your own interactive queries.
  
  NB: You can open and run this query directly from the Help menu, or with Ctrl+Shift+F1.
	
*****************************************************************************************/

SelectBox[] helpBoxes;
TextArea patternBox, inputBox, sourceCodeBox;
CheckBox[] optionBoxes;
DumpContainer results = new DumpContainer();

void Main()
{
	helpBoxes = GetHelpItems().Select (batch => new SelectBox (batch)).ToArray();

	foreach (var helpBox in helpBoxes)
	{
		helpBox.Width = (3 + (float)helpBox.Options [0].ToString().Length / 2) + "em";
		helpBox.SelectionChanged += (sender, args) =>
		{
			patternBox.Text += helpBox.SelectedOption.ToString().Split().First();
			helpBox.SelectedIndex = 0;
			Update();
			patternBox.Focus();
		};
	}

	patternBox = new TextArea (Util.LoadString ("Last regex pattern") ?? "", 90, Update);
	patternBox.SpellCheck = false;
	
	var clearPattern = new Hyperlink ("Clear", c => { patternBox.Text = ""; Update(); }) 
	{
		TabIndex = -1 
	};

	inputBox = new TextArea (Util.LoadString ("Last regex input") ?? "", 90, Update);
	inputBox.SpellCheck = false;

	string lastOptions = Util.LoadString ("Last regex options") ?? "";
	
	optionBoxes = Enum.GetValues (typeof (RegexOptions)).Cast<RegexOptions>()
		.Skip (1)
		.Select (o => new CheckBox (o.ToString(), onClick:Update) 
		{
			Tag = o,
			Checked = lastOptions.Contains (o.ToString())
		})
		.ToArray();

	sourceCodeBox = new TextArea ("", 100) { Enabled = false };

	foreach (var control in helpBoxes.Cast<Control>().Append (inputBox).Append (patternBox).Append (sourceCodeBox))
		control.Styles ["font-family"] = "consolas,monospace";
		
	inputBox.Styles ["font-size"] = patternBox.Styles ["font-size"] = "1.1em";

	Update();

	new WrapPanel (helpBoxes).Dump();
	new WrapPanel (patternBox, clearPattern).Dump ("Pattern");
	inputBox.Dump ("Input text");
	new WrapPanel (optionBoxes).Dump();
	results.Dump ("Matches");
	sourceCodeBox.Dump();
	new WrapPanel ("1em",
		new Button ("Copy to clipboard", b => System.Windows.Forms.Clipboard.SetText (sourceCodeBox.Text)),
		new Label ("Ctrl+Shift+C to clone query")).Dump();
		
	new Control ("small", "\r\nThis query uses LINQPad's HTML controls. Press Ctrl+R to see the source code.").Dump();

	patternBox.Focus();
	patternBox.SelectAll();
}

void Update (object sender = null)
{
	RegexOptions checkedOptions = GetOptions();
	
	results.Content = Util.Try (() => GetResult (checkedOptions), ex => ex);
	
	string optionsExpr = string.Join ("\r\n\t| ", checkedOptions.ToString().Split (',').Select (o => "RegexOptions." + o.Trim()));
	sourceCodeBox.Text = $@"Regex.Matches (input, @""{patternBox.Text.Replace ("\"", "\"\"")}""{PrefixUnlessEmpty (optionsExpr, ", ")})";
	
	Util.SaveString ("Last regex pattern", patternBox.Text);
	Util.SaveString ("Last regex input", inputBox.Text);
	Util.SaveString ("Last regex options", string.Join (" ", checkedOptions.ToString()));
}

object GetResult (RegexOptions checkedOptions) =>
	from Match m in Regex.Matches (inputBox.Text.Replace ("\r\n", "\n"), patternBox.Text, checkedOptions)
	select new
	{
		m.Index,
		m.Length,
		Value = new Hyperlink (m.Value,
			h => inputBox.HtmlElement.InvokeScript (false, "eval",
				 $"targetElement.setSelectionRange({m.Index}, {m.Index + m.Length}); targetElement.focus()")),
		m.Success,
		m.Name,
		m.Groups
	};

RegexOptions GetOptions() => optionBoxes
	.Where (o => o.Checked)
	.Aggregate (RegexOptions.None, (a, option) => a | (RegexOptions)option.Tag);
	
string PrefixUnlessEmpty (string expr, string prefix) => expr == "" ? "" : (prefix + expr);

string[][] GetHelpItems() => 
@" Character sets
 
.      any char except line break (or any char in SingleLine mode)
\d     a decimal digit
\D   !(a decimal digit)
\w     a word character    -- same as [a-zA-Z_0-9] in English
\W   !(a word character)
\s     a whitespace char   -- same as [ \n\r\t\f\v] in English
\S   !(a whitespace char)
 
[aeiou]     any char in set
[^aeiou]  !(any char in set)
[a-z]       any char in range
[^a-z]    !(any char in range)
[0-9a-z]    any char in multiple range
 
\p{L}   Letters
\p{Lu}  Uppercase letters
\p{Ll}  Lowercase letters
\p{N}   Numbers
\p{P}   Punctuation
\p{M}   Diacritic marks
\p{S}   Symbols
\p{Z}   Separators
\p{C}   Control characters

~~ Quantifiers
 
?      Zero or one matches     -- greedy
*      Zero or more matches    -- greedy
+      One or more matches     -- greedy
{n}    Exactly n matches       -- greedy
{n,}   At least n matches      -- greedy
{n,m}  Between n and m matches -- greedy
 
*?     Zero or more matches    -- lazy
+?     One or more matches     -- lazy
{n}?   Exactly n matches       -- lazy
{n,}?  At least n matches      -- lazy
{n,m}? Between n and m matches -- lazy 

~~ Zero-width assertions 
 
^   Start of string (or line in MultiLine mode)
$   End of string   (or line in MultiLine mode)
\A  Start of string (ignores MultiLine mode)
\z  End of string   (ignores MultiLine mode)
\Z  End of line or string
 
\b  On a word boundary
\B  Not on a word boundary
 
\G  Where search started
 
(?=expr)  Continue matching if expr matches on right       (positive lookahead)
(?!expr)  Continue matching if expr doesn’t match on right (negative lookahead)
(?<=expr) Continue matching if expr matches on left        (positive lookbehind)
(?<!expr) Continue matching if expr doesn’t match on left  (negative lookbehind)
(?>expr)  Match expr once without backtracking

~~ Alternation
 
|                 Logical or
foo|bar           Match foo OR bar
(foo|bar)abc      Match foo OR bar, followed by abc
(?(expr)foo|bar)  Match foo if expr matches,        otherwise match bar  (bar is optional)
(?(name)foo|bar)  Match foo if named group matches, otherwise match bar  (bar is optional)

~~ Grouping
 
(expr)     Capture matched expression expr into indexed group
(?number)  Capture matched substring into specified group number
(?'name')  Capture matched substring into specified group name
(?:expr)   Noncapturing group
 
\index     Reference a captured group by index
\k<name>   Reference a captured group by name

~~ Escapes
 
\t     Tab
\r     Carriage return
\v     Vertical tab
\f     Form feed
\n     Newline
\e     Escape
\xnn   ASCII character nn as hex (e.g., \x3F)
\cl    ASCII control character l (e.g., \cG for Ctrl+G)
\unnnn Unicode character nnnn as hex (e.g., \u07DE)

~~ Cookbook
 
 --- Extract or count words---
\b[\w-']+\b 
 
 --- Extract name=value pairs (one per line) ---
(?m)^\s*(?'name'\w+)\s*=\s*(?'value'.*)\s*(?=\r?$)
 
 --- Match http(s) URI ---
https?://[-A-Za-z0-9+&@#/%?=~_|!:,.;]*[-A-Za-z0-9+&@#/%=~_|]
 
 --- Match an email address (stackoverflow.com/questions/5342375) ---
[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))
 
 --- Match a Guid ---
[0-9a-fA-F]{8}\-([0-9a-fA-F]{4}\-){3}[0-9a-fA-F]{12}
 
 --- Match hexadecimal number ---
0[xX][0-9a-fA-F]+
 
 --- Match .NET full assembly name ---
[\w-]+,\sVersion=[\d\.]+,\sCulture=\w+,\sPublicKeyToken=[0-9a-f]{16}
 
 --- Match unprintable control characters ---
[\x00-\x08\x0B\x0C\x0E-\x1F]
 
 --- Strong password check (at least 8 chars including digit/symbol) ---
^(?=.*(\d|\p{P}|\p{S})).{8,}
 
 --- Parse F# compilation error/warning ---
\((\d+)\s*,\s*(\d+)\)\s*:\s*(error|warning)\s+(.+?):\s+(.*)
"
	.Split (new[] { "~~" }, StringSplitOptions.None)
	.Select (batch => batch.Split (new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
	.ToArray();