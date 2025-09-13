// LINQPad Statements

using System.Globalization;

// Util.Merge merges two or more objects together before dumping:

var o1 = new { A = 1, B = 2 };
var o2 = new { C = 3, D = 4 };

Util.Merge (o1, o2).Dump();

// You can also include simple values in the merge:

Util.Merge (o1, o2, "testing").Dump();

// This feature works in both Rich Text and Data Grid mode.