using System; // Provides Console and random number generation.
using System.Collections.Generic; // Provides List for prompt tracking.

namespace Mindfulness; // Keeps the class in the project namespace.

/// <summary> // Describes the reflection exercise.
 /// Helps the user reflect on a meaningful experience through guided questions.
 /// </summary>
public class ReflectionActivity : Activity // Inherits common activity attributes and methods.
{
    private readonly List<string> _prompts; // Stores reflection prompts privately.
    private readonly List<string> _questions; // Stores reflection questions privately.
    private readonly Random _random; // Generates random prompt and question selections.

    public ReflectionActivity() // Initializes the reflection activity.
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") // Initializes the inherited activity name and description.
    {
        _random = new Random(); // Creates the random number generator.
        _prompts = new List<string> // Creates the collection of reflection prompts.
        {
            "Think of a time when you stood up for someone else.", // Adds a prompt about courage.
            "Think of a time when you did something really difficult.", // Adds a prompt about perseverance.
            "Think of a time when you helped someone in need.", // Adds a prompt about kindness.
            "Think of a time when you did something truly selfless." // Adds a prompt about generosity.
        };
        _questions = new List<string> // Creates the collection of reflection questions.
        {
            "Why was this experience meaningful to you?", // Encourages the user to identify meaning.
            "Have you ever done anything like this before?", // Encourages comparison with past experiences.
            "How did you get started?", // Encourages reflection on the first step.
            "How did you feel when it was complete?", // Encourages emotional reflection.
            "What made this time different from other times when you were not as successful?", // Encourages comparison and learning.
            "What is your favorite thing about this experience?", // Encourages positive recollection.
            "What could you learn from this experience that applies to other situations?", // Connects the experience to future situations.
            "What did you learn about yourself through this experience?", // Encourages self-awareness.
            "How can you keep this experience in mind in the future?" // Encourages future application.
        };
    }

    protected override void PerformActivity() // Implements the reflection-specific exercise.
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration); // Sets the deadline for the reflection session.
        List<string> unusedPrompts = new List<string>(_prompts); // Copies prompts so each is used once before repeating.
        List<string> unusedQuestions = new List<string>(_questions); // Copies questions so each is used once before repeating.
        string prompt = PickWithoutRepeating(unusedPrompts, _prompts); // Selects a random prompt without immediate repetition.
        Console.WriteLine($"\n{prompt}"); // Displays the selected reflection prompt.
        Console.WriteLine("\nWhen you have something in mind, consider each question."); // Explains how to use the questions.
        while (DateTime.Now < endTime) // Continues reflection until the chosen duration has elapsed.
        {
            string question = PickWithoutRepeating(unusedQuestions, _questions); // Selects a question without repetition until the list cycles.
            Console.WriteLine($"\n{question}"); // Displays the current reflection question.
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds); // Calculates the time remaining.
            int pauseSeconds = Math.Min(5, remaining); // Limits each thinking pause to five seconds or less.
            ShowTimedSpinner(pauseSeconds); // Gives the user quiet thinking time with a spinner.
        }
    }

    private string PickWithoutRepeating(List<string> unusedItems, List<string> allItems) // Selects an item without repeating until the collection is exhausted.
    {
        if (unusedItems.Count == 0) // Checks whether every item has been used.
        {
            unusedItems.AddRange(allItems); // Resets the available items for another cycle.
        }

        int selectedIndex = _random.Next(unusedItems.Count); // Chooses a random available item.
        string selectedItem = unusedItems[selectedIndex]; // Saves the selected item.
        unusedItems.RemoveAt(selectedIndex); // Removes it so it cannot repeat in the current cycle.
        return selectedItem; // Returns the selected prompt or question.
    }
}
