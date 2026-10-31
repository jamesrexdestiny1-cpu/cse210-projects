
using System;

// Create a random number generator for the game.
Random randomGenerator = new Random();

// This loop allows the user to play the game repeatedly.
string playAgain = "yes";

while (playAgain.ToLower() == "yes")
{
    // Generate a random magic number between 1 and 100.
    // The upper limit of Next() is exclusive, so we use 101.
    int magicNumber = randomGenerator.Next(1, 101);

    // Initialize the guess counter at zero for each new game.
    int guessCount = 0;

    // Store the user's guess.
    int guess = -1;

    Console.WriteLine("\nWelcome to Guess My Number!");
    Console.WriteLine("I have picked a number between 1 and 100.");

    // Keep asking for guesses until the correct number is entered.
    while (guess != magicNumber)
    {
        // Ask the user to enter a guess.
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());

        // Count each guess made by the user.
        guessCount++;

        // Compare the guess with the magic number.
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            // This message appears when the user guesses correctly.
            Console.WriteLine("You guessed it!");
        }
    }

    // Display the total number of guesses after the game ends.
    Console.WriteLine($"You guessed the magic number in {guessCount} guesses.");

    // Ask whether the user wants to start another game.
    Console.Write("Would you like to play again? (yes/no): ");
    playAgain = Console.ReadLine().Trim();

    // Explain what happens if the user chooses not to continue.
    if (playAgain.ToLower() != "yes")
    {
        Console.WriteLine("Thanks for playing Guess My Number!");
    }
}
