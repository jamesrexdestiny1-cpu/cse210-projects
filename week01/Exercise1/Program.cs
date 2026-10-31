
 // Ask the user to enter their first name and display the prompt.
Console.Write("What is your first name? ");

// Read the first name entered by the user and store it in a variable.
string firstName = Console.ReadLine();

// Ask the user to enter their last name and display the prompt.
Console.Write("What is your last name? ");

// Read the last name entered by the user and store it in a variable.
string lastName = Console.ReadLine();

// Print an empty line to separate the input prompts from the final result.
Console.WriteLine();

// Display the name in the format: last name, first name, last name.
// The dollar sign ($) allows the variables to be inserted into the text.
Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
