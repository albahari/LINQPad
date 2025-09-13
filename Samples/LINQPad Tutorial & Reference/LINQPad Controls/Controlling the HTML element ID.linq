<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
</Query>

// LINQPad automatically assigns a unique ID to each underlying HTML element:

var txt = new TextBox ("testing").Dump();
txt.HtmlElement.ID.Dump ("ID automatically assigned");

// You can override this by setting the ID yourself before dumping the control:

var txt2 = new TextBox ("testing again");;
txt2.HtmlElement.ID = "foo";
txt2.Dump();

txt2.HtmlElement.ID.Dump ("ID manually assigned");

// The ID can be useful when writing JavaScript functions.
// For an example, see script://Demo_-_Bing_Maps