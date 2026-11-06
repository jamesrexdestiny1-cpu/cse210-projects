
using System;

public class Entry
{
    // Store the date when the journal entry was created.
    public string _date = "";

    // Store the writing prompt displayed to the user.
    public string _prompt = "";

    // Store the user's written response.
    public string _response = "";

    // Store the user's mood when creating the entry.
    public string _mood = "";

    // Default constructor used when creating or loading an entry.
    public Entry()
    {
    }

    // Constructor that initializes a new journal entry with its details.
    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    // Display all the information belonging to this journal entry.
    public void Display()
    {
        Console.WriteLine("----------------------------------------");

        // Display the date the entry was created.
        Console.WriteLine($"Date: {_date}");

        // Display the question that inspired the entry.
        Console.WriteLine($"Prompt: {_prompt}");

        // Display the user's recorded mood.
        Console.WriteLine($"Mood: {_mood}");

        // Display the user's journal response.
        Console.WriteLine($"Entry: {_response}");

        Console.WriteLine("----------------------------------------");
    }

    // Count and return the number of words in this journal response.
    public int GetWordCount()
    {
        // Remove unnecessary spaces and split the response into words.
        string[] words = _response.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        // Return the total number of words.
        return words.Length;
    }
}
