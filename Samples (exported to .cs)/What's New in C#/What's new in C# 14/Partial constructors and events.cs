// LINQPad Statements

// In C# 14, constructors and events can be declared as partial.

var p = new Person ("Ada Lovelace").Dump();
p.NameChanged += (sender, args) => p.Dump ("NameChanged");
p.Name += " 2";

partial class Person
{
	string _name;

	// Partial constructor signature
	public partial Person (string name);

	// Partial event signature
	public partial event EventHandler NameChanged;
}

partial class Person
{
	EventHandler _nameChanged;

	public string Name
	{
		get => _name;
		set
		{
			if (_name == value) return;
			_name = value;
			_nameChanged?.Invoke (this, EventArgs.Empty);			
		}
	}

	// Implementing declaration for the partial constructor
	public partial Person (string name) => Name = name;

	// Implementing declaration for the partial event
	public partial event EventHandler NameChanged
	{
		add => _nameChanged += value;
		remove => _nameChanged -= value;
	}
}
