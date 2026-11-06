
using System;

public class Program
{
    // Main method: the starting point of the journal application.
    static void Main(string[] args)
    {
        // Create a new Journal object to manage the user's entries.
        Journal journal = new Journal();

        // Store the user's menu selection.
        string choice = "";

        // Display the application title and welcome message.
        Console.WriteLine("========================================");
        Console.WriteLine("          PERSONAL JOURNAL APP          ");
        Console.WriteLine("========================================");
        Console.WriteLine("Welcome! Take a moment to reflect on your day.");

        // Continue displaying the menu until the user chooses to exit.
        while (choice != "6")
        {
            // Display the available journal operations.
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. View journal statistics");
            Console.WriteLine("6. Exit");

            // Ask the user to select an option.
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine() ?? "";

            // Perform the operation selected by the user.
            switch (choice)
            {
                case "1":
                    // Generate a random prompt and create a new entry.
                    WriteNewEntry(journal);
                    break;

                case "2":
                    // Display all entries currently stored in the journal.
                    journal.DisplayAll();
                    break;

                case "3":
                    // Ask for a filename and save the journal.
                    SaveJournal(journal);
                    break;

                case "4":
                    // Ask for a filename and load the journal.
                    LoadJournal(journal);
                    break;

                case "5":
                    // Display additional information about journal activity.
                    DisplayStatistics(journal);
                    break;

                case "6":
                    // Display a closing message before ending the application.
                    Console.WriteLine("Thank you for using the Personal Journal App!");
                    Console.WriteLine("Keep reflecting and recording your experiences.");
                    break;

                default:
                    // Handle menu selections that are not recognized.
                    Console.WriteLine("Invalid option. Please select a number from 1 to 6.");
                    break;
            }
        }
    }

    // Create a new journal entry using a randomly selected writing prompt.
    static void WriteNewEntry(Journal journal)
    {
        // Get a random question from the PromptGenerator class.
        string prompt = PromptGenerator.GetRandomPrompt();

        // Display the selected prompt to the user.
        Console.WriteLine("\nWriting Prompt:");
        Console.WriteLine(prompt);

        // Ask the user to write a response to the prompt.
        Console.Write("\nYour response: ");
        string response = Console.ReadLine() ?? "";

        // Ask the user to record their current mood.
        Console.Write("How are you feeling today? ");
        string mood = Console.ReadLine() ?? "";

        // Automatically record the current date.
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        // Create a new Entry object containing all the collected information.
        Entry newEntry = new Entry(date, prompt, response, mood);

        // Add the newly created entry to the journal.
        journal.AddEntry(newEntry);

        // Confirm that the entry has been added successfully.
        Console.WriteLine("\nYour journal entry has been recorded successfully!");
    }

    // Ask the user for a filename and save the journal to that file.
    static void SaveJournal(Journal journal)
    {
        // Request the destination filename from the user.
        Console.Write("\nEnter the filename to save your journal: ");
        string filename = Console.ReadLine() ?? "";

        // Check that the user supplied a filename.
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            // Save all journal entries using the Journal class.
            journal.SaveToFile(filename);

            // Confirm that the journal was saved successfully.
            Console.WriteLine($"Journal successfully saved to {filename}.");
        }
        catch (Exception error)
        {
            // Inform the user if the saving operation fails.
            Console.WriteLine($"Unable to save the journal: {error.Message}");
        }
    }

    // Ask the user for a filename and load the journal from that file.
    static void LoadJournal(Journal journal)
    {
        // Request the filename containing the saved journal.
        Console.Write("\nEnter the filename to load your journal: ");
        string filename = Console.ReadLine() ?? "";

        // Check that the user supplied a filename.
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            // Load the selected file and replace the current journal entries.
            journal.LoadFromFile(filename);

            // Confirm that the journal was loaded successfully.
            Console.WriteLine("Journal loaded successfully!");

            // Display the number of entries recovered from the file.
            Console.WriteLine($"Total entries loaded: {journal.GetEntryCount()}");
        }
        catch (Exception error)
        {
            // Inform the user if the file cannot be loaded.
            Console.WriteLine($"Unable to load the journal: {error.Message}");
        }
    }

    // Display statistics that help users track their journaling activity.
    static void DisplayStatistics(Journal journal)
    {
        // Retrieve the total number of saved entries.
        int entryCount = journal.GetEntryCount();

        // Retrieve the combined number of words across all entries.
        int totalWords = journal.GetTotalWordCount();

        // Display the journal statistics.
        Console.WriteLine("\n========== JOURNAL STATISTICS ==========");
        Console.WriteLine($"Total journal entries: {entryCount}");
        Console.WriteLine($"Total words written: {totalWords}");

        // Display a helpful message when the journal is still empty.
        if (entryCount == 0)
        {
            Console.WriteLine("Start writing today to build your journal!");
        }
        else
        {
            // Calculate and display the average words per entry.
            double averageWords = (double)totalWords / entryCount;

            Console.WriteLine($"Average words per entry: {averageWords:F2}");
        }

        Console.WriteLine("========================================");
    }
}

/*
 * ADDITIONAL FEATURES IMPLEMENTED TO EXCEED THE CORE REQUIREMENTS:
 *
 * 1. Mood Tracking:
 *    Each journal entry includes a mood field so users can record
 *    how they felt when writing their daily reflection.
 *
 * 2. JSON File Storage:
 *    Journal entries are saved and loaded using JSON rather than
 *    a basic text separator. This provides structured and readable
 *    storage for the journal data.
 *
 * 3. Journal Statistics:
 *    Users can view the total number of entries, the total words
 *    written, and the average number of words per entry.
 *
 * 4. Expanded Writing Prompts:
 *    The application provides ten different prompts to encourage
 *    regular reflection and help users overcome writer's block.
 *
 * These improvements make the application more useful while
 * maintaining the abstraction and class responsibilities required
 * by the assignment.
 */
