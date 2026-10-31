
using System;

// The main function controls the program by calling each function
// in the correct order and passing information between them.
class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message to the user.
        DisplayWelcome();

        // Ask the user for their name and store the returned value.
        string name = PromptUserName();

        // Ask the user for their favorite number and store the result.
        int number = PromptUserNumber();

        // Calculate the square of the user's favorite number.
        int squaredNumber = SquareNumber(number);

        // Display the user's name and the squared number.
        DisplayResult(name, squaredNumber);
    }

    // Displays a welcome message at the beginning of the program.
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks the user to enter their name and returns it as a string.
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // Asks the user for their favorite number and returns it as an integer.
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    // Receives an integer and returns its square by multiplying it by itself.
    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;

        return squaredNumber;
    }

    // Displays the user's name and the square of their favorite number.
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
