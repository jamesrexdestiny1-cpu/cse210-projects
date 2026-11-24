using System; // Provides Console and DateTime.
using System.Collections.Generic; // Provides List for storing user entries.
using System.Diagnostics; // Provides Stopwatch for accurate timing.
using System.Text; // Provides StringBuilder for typed input.

namespace Mindfulness; // Keeps the class in the project namespace.

/// <summary> // Describes the listing exercise.
 /// Prompts the user to list positive people, strengths, or experiences.
 /// </summary>
public class ListingActivity : Activity // Inherits shared activity information and behavior.
{
    private readonly List<string> _prompts; // Stores possible listing prompts privately.
    private readonly Random _random; // Selects a prompt at random.
    private readonly List<string> _entries; // Stores the items entered during this session.

    public ListingActivity() // Initializes the listing activity.
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") // Passes shared information to the base class.
    {
        _random = new Random(); // Creates a random number generator.
        _entries = new List<string>(); // Creates an empty list for this session's answers.
        _prompts = new List<string> // Creates the listing prompt collection.
        {
            "Who are people that you appreciate?", // Prompts gratitude for people.
            "What are personal strengths of yours?", // Prompts recognition of strengths.
            "Who are people that you have helped this week?", // Prompts reflection on service.
            "When have you felt peaceful or encouraged recently?", // Adds a broadly accessible positive prompt.
            "Who are some of your personal heroes?" // Prompts recognition of role models.
        };
    }

    protected override void PerformActivity() // Implements the listing-specific exercise.
    {
        _entries.Clear(); // Ensures the count starts at zero for every new session.
        string prompt = _prompts[_random.Next(_prompts.Count)]; // Selects one random listing prompt.
        Console.WriteLine($"\nList as many responses as you can to the following prompt:"); // Introduces the listing task.
        Console.WriteLine($"--- {prompt} ---"); // Displays the selected prompt.
        Console.WriteLine("\nYou will have a few seconds to think before entering your items."); // Explains the preparation period.
        ShowCountDown(Math.Min(5, Duration)); // Gives the user up to five seconds to prepare.
        Console.WriteLine("\nStart listing now. Press ENTER after each item."); // Explains how to submit each item.
        Console.WriteLine("The session ends automatically when the time is up."); // Explains the time limit.
        CollectEntriesForDuration(); // Collects responses without allowing input to block the timer.
        Console.WriteLine($"\nYou listed {_entries.Count} item(s)."); // Reports the number of items entered.
        if (_entries.Count > 0) // Checks whether the user entered at least one item.
        {
            Console.WriteLine("Your entries:"); // Introduces the user's list.
            for (int index = 0; index < _entries.Count; index++) // Iterates through every saved entry.
            {
                Console.WriteLine($"{index + 1}. {_entries[index]}"); // Displays each item with a number.
            }
        }
    }

    private void CollectEntriesForDuration() // Reads keyboard input while continuously checking the time limit.
    {
        Stopwatch stopwatch = Stopwatch.StartNew(); // Starts a reliable elapsed-time counter.
        StringBuilder currentEntry = new StringBuilder(); // Stores the text currently being typed.
        while (stopwatch.Elapsed.TotalSeconds < Duration) // Continues until the selected duration has elapsed.
        {
            if (Console.KeyAvailable) // Checks for a key without blocking the timer.
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // Reads the key without automatically echoing it.
                if (key.Key == ConsoleKey.Enter) // Checks whether the user has finished an item.
                {
                    SaveCurrentEntry(currentEntry); // Saves a non-empty entry.
                    currentEntry.Clear(); // Prepares for the next item.
                    Console.WriteLine(); // Moves to a fresh line.
                }
                else if (key.Key == ConsoleKey.Backspace && currentEntry.Length > 0) // Handles deletion when text exists.
                {
                    currentEntry.Length--; // Removes the last character from the input buffer.
                    Console.Write("\b \b"); // Erases the last visible character.
                }
                else if (!char.IsControl(key.KeyChar)) // Ignores control characters that are not handled above.
                {
                    currentEntry.Append(key.KeyChar); // Adds the typed character to the current entry.
                    Console.Write(key.KeyChar); // Displays the character so the user can see what they typed.
                }
            }
            else // Runs when no key is waiting.
            {
                System.Threading.Thread.Sleep(25); // Briefly rests the loop to avoid unnecessary processor use.
            }
        }

        SaveCurrentEntry(currentEntry); // Saves any final item typed before the timer expired.
        stopwatch.Stop(); // Stops the elapsed-time counter.
        Console.WriteLine(); // Adds spacing after the timed input period.
    }

    private void SaveCurrentEntry(StringBuilder currentEntry) // Saves the current response if it contains meaningful text.
    {
        string entry = currentEntry.ToString().Trim(); // Removes unnecessary spaces from the response.
        if (!string.IsNullOrWhiteSpace(entry)) // Checks that the response is not empty.
        {
            _entries.Add(entry); // Adds the response to the session list.
        }
    }
}
