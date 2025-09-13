<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Namespace>System.Globalization</Namespace>
</Query>

// There's also a Util.Snapshot method to 'snapshot' an object so you can later compare it with itself.

var numbers = Enumerable.Range (0, 30).ToList();
var snapshot = Util.Snapshot (numbers);               // Take a snapshot

numbers[10] *=10;                                     // Make changes to the object
numbers.Insert (20, 100000);

Util.Dif (snapshot, numbers).Dump();