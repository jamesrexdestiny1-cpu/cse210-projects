using System; // Provides Console and input handling.

namespace Mindfulness; // Keeps the entry point in the project namespace.

/// <summary> // Describes the application entry point.
 /// Presents the menu and coordinates mindfulness activities.
 /// </summary>
public class Program // Defines the main program class.
{
    public static void Main(string[] args) // Starts program execution.
    {
        SessionLogger logger = new SessionLogger(); // Creates the optional persistent session logger.
        bool running = true; // Controls whether the menu should continue.

        // CREATIVITY / FEATURES BEYOND THE CORE REQUIREMENTS:
        // 1. A session history is saved to mindfulness-session-log.txt and can be viewed from the menu.
        // 2. Reflection prompts and questions are shuffled by random selection without repeating until each list has been used.
        // 3. Listing accepts multiple entries during a strict timed window and reports and displays the entries.
        // 4. Input validation prevents zero, negative, or non-numeric activity durations.
        // 5. The breathing activity uses timed inhale/exhale phases, while all pauses use visible animations.
        // These additions improve usability while preserving the required inheritance-based design.

        while (running) // Repeats the menu until the user chooses to quit.
        {
            Console.Clear(); // Clears the screen before displaying the menu.
            Console.WriteLine("MINDFULNESS PROGRAM"); // Displays the application title.
            Console.WriteLine("==================="); // Adds a visual separator.
            Console.WriteLine("1. Start Breathing Activity"); // Offers the breathing activity.
            Console.WriteLine("2. Start Reflection Activity"); // Offers the reflection activity.
            Console.WriteLine("3. Start Listing Activity"); // Offers the listing activity.
            Console.WriteLine("4. View Session History"); // Offers the additional history feature.
            Console.WriteLine("5. Quit"); // Offers the exit option.
            Console.Write("Select a choice from the menu: "); // Requests the user's menu selection.
            string? choice = Console.ReadLine(); // Reads the selected menu option.

            switch (choice) // Routes the selection to the appropriate feature.
            {
                case "1": // Handles the breathing activity option.
                    RunActivity(new BreathingActivity(), logger); // Creates and runs a breathing activity.
                    break; // Ends this menu case.
                case "2": // Handles the reflection activity option.
                    RunActivity(new ReflectionActivity(), logger); // Creates and runs a reflection activity.
                    break; // Ends this menu case.
                case "3": // Handles the listing activity option.
                    RunActivity(new ListingActivity(), logger); // Creates and runs a listing activity.
                    break; // Ends this menu case.
                case "4": // Handles the session history option.
                    logger.ShowHistory(); // Displays the saved session history.
                    break; // Ends this menu case.
                case "5": // Handles the quit option.
                    running = false; // Ends the menu loop.
                    Console.WriteLine("\nThank you for taking time to be mindful"); // Displays a friendly exit message.
                    break; // Ends this menu case.
                default: // Handles invalid menu selections.
                    Console.WriteLine("\nThat is not a valid option. Press ENTER and try again."); // Explains the invalid selection.
                    Console.ReadLine(); // Waits before showing the menu again.
                    break; // Ends the default case.
            }
        }
    }

    private static void RunActivity(Activity activity, SessionLogger logger) // Runs any activity through the common base-class type.
    {
        activity.Run(); // Uses the inherited common workflow and polymorphic activity behavior.
        logger.RecordSession(activity.GetType().Name, GetCompletedDuration(activity)); // Saves the completed activity to the history file.
        Console.WriteLine("\nPress ENTER to return to the main menu."); // Tells the user how to return.
        Console.ReadLine(); // Waits before returning to the menu.
    }

    private static int GetCompletedDuration(Activity activity) // Gets the duration for logging without exposing a writable field.
    {
        return activity.CompletedDuration; // Returns the duration exposed by the base class.
    }
}
