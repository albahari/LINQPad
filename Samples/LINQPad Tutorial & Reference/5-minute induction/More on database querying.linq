<query Kind="Statements" />

//	DO I NEED TO SET UP FOREIGN KEY CONSTRAINTS ON MY TABLES?
	
		"YES!!!".Dump ("Foreign key constraints");

/*	Foreign key constraints are essential if you want parent and child properties to
	magically appear in blue and green. Otherwise you'll have to join manually like in
	old SQL (ugghh!) No doubt you already have such constraints in your databases, right? 

	DO I NEED TO BUILD A TYPED DATACONTEXT?									*/

		"NO!!!".Dump ("Typed DataContext");

//	LINQPad takes care of this detail :)  Just start querying!