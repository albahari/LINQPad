<Query Kind="Program" />

// We can also match against tuples:

void Main()
{
	RockPaperScissors ("paper", "rock").Dump();
}

public static string RockPaperScissors (string first, string second)
	=> (first, second) switch
	{
		("rock", "paper")     => "rock is covered by paper. Paper wins.",
		("rock", "scissors")  => "rock breaks scissors. Rock wins.",
		("paper", "rock")     => "paper covers rock. Paper wins.",
		("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
		("scissors", "rock")  => "scissors is broken by rock. Rock wins.",
		("scissors", "paper") => "scissors cuts paper. Scissors wins.",
		(_, _) => "tie"
	};

// See https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns