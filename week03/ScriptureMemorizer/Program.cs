
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        /*
         * CREATIVITY AND EXCEEDING REQUIREMENTS:
         *
         * 1. Scripture Library:
         *    The program contains multiple scriptures and randomly
         *    selects one for the user to memorize.
         *
         * 2. Smart Word Selection:
         *    It selects only words that have not already been hidden.
         *    This prevents wasting a hiding turn on an already hidden word.
         *
         * 3. Memorization Progress:
         *    The program displays the number and percentage of words
         *    hidden after each round.
         *
         * 4. Punctuation Preservation:
         *    When words are hidden, punctuation remains visible while
         *    each letter is replaced by a matching underscore.
         */

        // Create a small library of scriptures.
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            )
        };

        // Randomly select one scripture from the library.
        Random random = new Random();
        Scripture selectedScripture = scriptures[
            random.Next(scriptures.Count)
        ];

        // Display the selected scripture for the first time.
        Console.Clear();
        DisplayScripture(selectedScripture);

        // Continue until the user quits or all words are hidden.
        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide up to 3 more words.");
            Console.WriteLine("Type 'quit' to exit the program.");

            string input = Console.ReadLine() ?? "";

            // Allow the user to end the program at any time.
            if (input.Trim().Equals(
                "quit",
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for practicing!");
                return;
            }

            // Do not hide words if the user enters other text.
            if (input.Length > 0)
            {
                Console.WriteLine("Please press ENTER or type quit.");
                continue;
            }

            // Hide up to three words that are still visible.
            selectedScripture.HideRandomWords(3);

            // Clear the previous display and show the updated scripture.
            Console.Clear();
            DisplayScripture(selectedScripture);
        }

        // Display a completion message after every word is hidden.
        Console.WriteLine();
        Console.WriteLine("Congratulations! You have hidden every word.");
        Console.WriteLine("You have completed this scripture memorization practice.");
    }

    // Displays the scripture and the user's memorization progress.
    private static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine("===== SCRIPTURE MEMORIZER =====");
        Console.WriteLine();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();

        Console.WriteLine(
            $"Words hidden: {scripture.GetHiddenWordCount()} / {scripture.GetTotalWordCount()}"
        );

        Console.WriteLine(
            $"Memorization progress: {scripture.GetProgressPercentage():F0}%"
        );
    }
}
