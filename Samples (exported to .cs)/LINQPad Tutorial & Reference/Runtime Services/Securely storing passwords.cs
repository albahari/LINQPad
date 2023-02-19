// LINQPad Statements

/* Sometimes you need to supply a password (e.g., to access cloud services), without hard-coding it into the script.

   Hard-coding a password into a script is bad for two reasons:
     1. The password will be stored in plain text
     2. Changing the password will potentially require updating multiple scripts
   
   The good news is that LINQPad includes a password manager that securely saves passwords via the Windows Data Protection API.
   
   To request a password from code, call Util.GetPassword:   */

// Prompts user for password, optionally saving it to secure storage:
string password = Util.GetPassword ("My Azure Blob Storage Account");
password.Dump ("this is the password");

// To view, change or clear passwords, go to LINQPad's File menu and choose 'Password Manager'.
//
// You can also update/clear passwords programmatically by calling Util.SetPassword.