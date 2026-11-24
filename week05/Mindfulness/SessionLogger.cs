using System; // Provides DateTime and Console.
using System.IO; // Provides file-writing functionality.

namespace Mindfulness; // Keeps the class in the project namespace.

/// <summary> // Describes the optional session history feature.
 /// Saves completed activity details to a local text file.
 /// </summary>
public class SessionLogger // Keeps logging responsibilities separate from activity classes.
{
    private readonly string _filePath; // Stores the log file path privately.

    public SessionLogger() // Creates the logger and chooses its local file.
    {
        _filePath = "mindfulness-session-log.txt"; // Saves the log in the program's working directory.
    }

    public void RecordSession(string activityName, int duration) // Records one completed session.
    {
        string record = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activityName} | {duration} seconds"; // Formats the session details.
        File.AppendAllText(_filePath, record + Environment.NewLine); // Appends the record without deleting earlier sessions.
    }

    public void ShowHistory() // Displays saved session records.
    {
        Console.Clear(); // Clears the previous screen.
        Console.WriteLine("MINDFULNESS SESSION HISTORY"); // Displays the history heading.
        Console.WriteLine("----------------------------"); // Separates the heading from the records.
        if (File.Exists(_filePath)) // Checks whether a history file has been created.
        {
            string history = File.ReadAllText(_filePath); // Reads all previously saved records.
            Console.WriteLine(string.IsNullOrWhiteSpace(history) ? "No sessions have been recorded yet." : history); // Displays records or an empty-history message.
        }
        else // Runs when no history file exists.
        {
            Console.WriteLine("No sessions have been recorded yet."); // Explains that there is no saved history.
        }

        Console.WriteLine("\nPress ENTER to return to the menu."); // Tells the user how to continue.
        Console.ReadLine(); // Waits for the user before returning.
    }
}
