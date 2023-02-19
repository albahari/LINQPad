<Query Kind="FSharpProgram" />

type Card = { Name  : string;
			  Phone : string;
			  Ok    : bool }
			  
let cardA = { Name = "Alf" ; Phone = "(206) 555-0157" ; Ok = false }
let cardB = { cardA with Phone = "(206) 555-0112"; Ok = true }
let ShowCard c = 
  c.Name + " Phone: " + c.Phone + (if not c.Ok then " (unchecked)" else "")

cardA.Dump ("cardA")
cardB.Dump ("cardA")
(ShowCard cardA).Dump ("ShowCard cardA")  