<Query Kind="Statements" />

// You can display a LaTeX formula with Util.Latex.

string latex = @"\sum_{n=1}^{\infty} \frac{1}{n^2} = \frac{\pi^2}{6}";
Util.Latex (latex, fontSize: "13pt").Dump ("Basel Problem");

Util.HorizontalRun (true,
	"Entropy is defined as",
	Util.Latex (@"S = -k_B \sum_i p_i \ln p_i", inline: true),
	"for discrete probability distributions.")
.Dump ("Inline formula");

// Util.Latex returns an interactive LINQPad control (LINQPad.Controls.LatexViewer) that can be subsequently updated.
//  - see script://../../LINQPad_Controls