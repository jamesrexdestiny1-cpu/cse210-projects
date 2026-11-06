
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    // Store all journal entries in a list.
    private List<Entry> _entries = new List<Entry>();

    // Configure JSON formatting to make saved files readable.
    // IncludeFields allows the serializer to save our underscore-prefixed fields.
    private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };

    // Add a new entry to the journal collection.
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Display every entry currently stored in the journal.
    public void DisplayAll()
    {
        // Check whether the journal contains any entries.
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }

        // Display each entry using its own Display method.
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save all journal entries to the filename provided by the user.
    public void SaveToFile(string filename)
    {
        // Convert the complete journal collection into formatted JSON.
        string json = JsonSerializer.Serialize(_entries, _jsonOptions);

        // Write the JSON content to the selected file.
        File.WriteAllText(filename, json);
    }

    // Load journal entries from a selected JSON file.
    public void LoadFromFile(string filename)
    {
        // Read the complete contents of the selected file.
        string json = File.ReadAllText(filename);

        // Convert the JSON content back into a list of Entry objects.
        List<Entry>? loadedEntries =
            JsonSerializer.Deserialize<List<Entry>>(json, _jsonOptions);

        // Replace the current journal with the loaded entries.
        // This prevents old entries from being duplicated.
        _entries = loadedEntries ?? new List<Entry>();
    }

    // Return the total number of entries in the journal.
    public int GetEntryCount()
    {
        return _entries.Count;
    }

    // Calculate the total number of words written across all entries.
    public int GetTotalWordCount()
    {
        // Start the word counter at zero.
        int totalWords = 0;

        // Add the word count of each entry to the total.
        foreach (Entry entry in _entries)
        {
            totalWords += entry.GetWordCount();
        }

        // Return the combined word count.
        return totalWords;
    }
}
