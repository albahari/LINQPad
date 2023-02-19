<Query Kind="Statements" />

// You can use 'and', 'or' and 'not' to combine patterns.

int x = 150;
(x is > 100 and < 200).Dump ($"{x} is between 100 and 200");

char c = 'e';
(c is 'a' or 'e' or 'i' or 'o' or 'u').Dump ($"{c} is a vowel");

// 'and' has higher precedence than 'or'. You can use parentheses to override precedence.

// Combinators are also useful in switches:

GetWeightJudgement (16.5m).Dump();
GetWeightJudgement (22.3m).Dump();

string GetWeightJudgement (decimal bmi) => bmi switch
{
	>= 18.5m and < 25m => "healthy",
	< 15m or > 30m => "very unhealthy",
	_ => "somewhat unhealthy"
};