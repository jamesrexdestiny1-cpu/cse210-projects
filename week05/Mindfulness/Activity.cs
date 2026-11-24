using System; // Provides Console and other fundamental .NET types.
using System.Threading; // Provides Thread.Sleep for timed pauses.

namespace Mindfulness; // Keeps all project classes in one namespace.

/// <summary> // Explains the shared activity abstraction.
 /// Stores information and behavior common to every mindfulness activity.
 /// </summary>
public abstract class Activity // Defines the parent class inherited by each activity.
{
    private readonly string _activityName; // Stores the activity name privately.
    private readonly string _description; // Stores the activity description privately.
    private int _duration; // Stores the selected duration privately.

    protected Activity(string activityName, string description) // Initializes shared activity information.
    {
        _activityName = activityName; // Saves the activity name.
        _description = description; // Saves the activity description.
        _duration = 0; // Sets a safe initial duration before the user chooses one.
    }

    protected int Duration => _duration; // Gives derived classes read-only access to the selected duration.
    protected string ActivityName => _activityName; // Gives derived classes read-only access to the activity name.
    public int CompletedDuration => _duration; // Exposes the completed duration as read-only data for session logging.

    public void Run() // Provides the common workflow inherited by all activities.
    {
        DisplayStartingMessage(); // Shows the common introduction and asks for a duration.
        PerformActivity(); // Runs the activity-specific behavior implemented by a child class.
        DisplayEndingMessage(); // Shows the common completion message.
    }

    private void DisplayStartingMessage() // Keeps the shared start-message responsibility in the base class.
    {
        Console.Clear(); // Clears old menu or activity text.
        Console.WriteLine($"\nWelcome to the {_activityName}."); // Displays the activity title.
        Console.WriteLine(); // Adds readable vertical whitespace.
        Console.WriteLine(_description); // Explains the purpose of the activity.
        Console.WriteLine(); // Separates the description from the duration prompt.
        _duration = ReadDuration(); // Gets and stores a valid duration from the user.
        Console.WriteLine("\nGet ready..."); // Tells the user the activity is about to begin.
        ShowSpinner(3); // Gives the user three seconds to prepare with an animation.
    }

    private int ReadDuration() // Validates the duration entered by the user.
    {
        while (true) // Repeats until a positive whole number is entered.
        {
            Console.Write("How long, in seconds, would you like for your session? "); // Requests the duration.
            string? input = Console.ReadLine(); // Reads the user's response safely.
            if (int.TryParse(input, out int seconds) && seconds > 0) // Checks that the response is a positive integer.
            {
                return seconds; // Returns the valid duration to the caller.
            }

            Console.WriteLine("Please enter a whole number greater than zero."); // Explains the input requirement.
        }
    }

    protected abstract void PerformActivity(); // Requires every derived activity to implement its own exercise.

    protected void DisplayEndingMessage() // Provides the common completion workflow to all derived classes.
    {
        Console.WriteLine("\nWell done!"); // Congratulates the user.
        ShowSpinner(2); // Pauses briefly with a visible spinner.
        Console.WriteLine($"\nYou have completed the {_activityName} for {_duration} seconds."); // Reports the completed activity and duration.
        ShowSpinner(3); // Gives the user a final animated pause.
    }

    protected void ShowSpinner(int seconds) // Displays a rotating animation during a pause.
    {
        char[] frames = { '|', '/', '-', '\\' }; // Defines the four spinner characters.
        DateTime endTime = DateTime.Now.AddSeconds(seconds); // Calculates when the animation should stop.
        int frameIndex = 0; // Tracks the next spinner character.
        while (DateTime.Now < endTime) // Continues until the requested pause has elapsed.
        {
            Console.Write(frames[frameIndex % frames.Length]); // Displays the current spinner frame.
            Thread.Sleep(150); // Waits briefly so the animation is visible.
            Console.Write("\b \b"); // Erases the previous character using backspaces.
            frameIndex++; // Advances to the next spinner frame.
        }
    }

    protected void ShowCountDown(int seconds) // Displays a numeric countdown with an animated pause.
    {
        for (int remaining = seconds; remaining > 0; remaining--) // Counts down one second at a time.
        {
            Console.Write($"{remaining} "); // Displays the number of seconds remaining.
            Thread.Sleep(1000); // Pauses for one second.
            Console.Write("\b\b   \b\b"); // Clears the displayed number before the next one.
        }
    }

    protected void ShowTimedSpinner(int seconds) // Shows a spinner for a duration supplied by an activity.
    {
        ShowSpinner(seconds); // Reuses the shared spinner implementation.
    }
}
