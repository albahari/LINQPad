// LINQPad Statements

// Should a subclass and base class define members with the same name,
// the subclass will normally "win" and hide the base class's member.
// 
// To access the base class member, use the @base member:

var sub = new SubClass();
	
sub.Uncapsulate().      _x.Dump ("SubClass's _x");
sub.Uncapsulate().@base._x.Dump ("BaseClass's _x");

// You can also access the base member with a cast:	
sub.Uncapsulate().CastTo("BaseClass")._x.Dump ("BaseClass's _x");

class BaseClass
{
	string _x = "base class";
}

class SubClass : BaseClass
{
	string _x = "subclass";
}