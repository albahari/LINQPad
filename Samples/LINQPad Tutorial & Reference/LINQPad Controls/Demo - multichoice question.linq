<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

// In this example, we create a Control for implementing a multichoice question.

using LINQPad.Controls;

record MultichoiceOption (string Text, bool IsCorrect = false);

class MultichoiceQuestion : Div
{
	readonly Control _question;
	readonly MultichoiceOption[] _options;

	// Allow the question to be specified as a simple string or a Control:
	
	public MultichoiceQuestion (string question, params MultichoiceOption[] options)
		: this (new Span (question) { Styles = { ["white-space"] = "pre-line" } }, options)
	{}

	public MultichoiceQuestion (Control question, params MultichoiceOption[] options)
	{
		_question = question;
		_options = options;

		var radioButtons = _options.Select ((opt, i) => new RadioButton ("answer", opt.Text)).ToArray();

		var feedback = new Label();

		var submitButton = new Button ("Submit", btn =>
		{
			var selectedIndex = Array.FindIndex (radioButtons, rb => rb.Checked);
			if (selectedIndex == -1)
			{
				feedback.Text = "Please select an answer";
			}
			else if (_options [selectedIndex].IsCorrect)
			{
				var correctAnswers = _options.Where (o => o.IsCorrect).Select (o => o.Text);
				var allCorrectText = correctAnswers.Count() > 1
					? $"All correct answers: {string.Join (", ", correctAnswers)}"
					: "";
				feedback.Text = $"✓ Correct! {allCorrectText}";
			}
			else
			{
				feedback.Text = "✗ Incorrect. Try again.";
			}
		});

		this.Children.Add (new Label (_question) { Styles = { ["font-weight"] = "bold" }});
		this.Children.Add (new StackPanel (false, radioButtons) { Styles = { ["margin"] = ".3em 0 .5em 0" }});
		this.Children.Add (new StackPanel (true, ".5em", submitButton, feedback));

		this.Styles ["margin-bottom"] = "1em";
	}
}

void Main()
{
	new MultichoiceQuestion ("What's the capital of New Zealand?",
		new ("Paris"),
		new ("Auckland", true),
		new ("London"),
		new ("New York"),
		new ("Frankfurt")
	).Dump ("");
	
	new MultichoiceQuestion (new Literal ("""
		Given the following C# code:
		<pre>
		    var x = 10 / 3;
		</pre>
		What does <code>x</code> evaluate to?
		"""),
		new ("0"),
		new ("3", true),
		new ("3.33333333333333"),
		new ("This will not compile"),
		new ("This will throw an exception")
	).Dump ("");
}