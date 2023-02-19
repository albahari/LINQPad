<Query Kind="Statements" />

// The relational pattern lets you use <, >, <= and >= in patterns:

GetWeightCategory (16.5m).Dump();
GetWeightCategory (22.3m).Dump();

string GetWeightCategory (decimal bmi) => bmi switch
{
	< 18.5m => "underweight",
	< 25m => "normal",
	< 30m => "overweight",
	_ => "obese"
};

// You can also use the relational pattern in simple expressions,
// although it's not very useful on its own...

int x = 150;
(x is > 100).Dump ($"{x} is greater than 100");