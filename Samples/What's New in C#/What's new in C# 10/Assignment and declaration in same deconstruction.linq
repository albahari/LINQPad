<Query Kind="Statements" />

var point = new Point (3, 4);

double x = 0;
(x, double y) = point;    // Illegal prior to C# 10

(x, y).Dump();
	
record Point (double X, double Y);