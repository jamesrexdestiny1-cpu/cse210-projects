using System; // Provides Console and DateTime.

namespace Mindfulness; // Keeps the class in the project namespace.

/// <summary> // Describes the breathing exercise.
 /// Guides the user through alternating inhaling and exhaling cycles.
 /// </summary>
public class BreathingActivity : Activity // Inherits shared data and workflow from Activity.
{
    public BreathingActivity() // Creates a breathing activity with its own description.
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") // Passes shared details to the base constructor.
    {
    }

    protected override void PerformActivity() // Implements the breathing-specific exercise.
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration); // Calculates the exact end time for the exercise.
        bool breatheIn = true; // Makes the first instruction an inhale.
        while (DateTime.Now < endTime) // Repeats breathing cycles until the selected duration ends.
        {
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds); // Calculates the whole seconds still available.
            int cycleSeconds = Math.Min(4, remaining); // Uses a four-second breath phase or the remaining time if shorter.
            Console.WriteLine(breatheIn ? "\nBreathe in..." : "\nBreathe out..."); // Displays the current breathing instruction.
            ShowCountDown(cycleSeconds); // Counts down the duration of this breath phase.
            breatheIn = !breatheIn; // Switches between inhaling and exhaling.
        }
    }
}
