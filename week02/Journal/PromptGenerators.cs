
using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Store a collection of writing prompts for the journal.
    // The prompts encourage users to reflect on their daily experiences.
    private static List<string> _prompts = new List<string>
    {
        "What was the most meaningful moment of your day?",

        "Who made a positive difference in your life today?",

        "What is one thing you learned today?",

        "What challenge did you face today, and how did you handle it?",

        "What are three things you are grateful for today?",

        "How did you see the hand of the Lord in your life today?",

        "What is one thing you would like to improve about yourself?",

        "What made you smile or laugh today?",

        "What is one goal you want to accomplish tomorrow?",

        "If you could relive one moment from today, what would it be?"
    };

    // Create a random number generator to select prompts.
    private static Random _randomGenerator = new Random();

    // Select and return one random prompt from the collection.
    public static string GetRandomPrompt()
    {
        // Generate a random index within the prompt collection.
        int index = _randomGenerator.Next(_prompts.Count);

        // Return the prompt located at the selected index.
        return _prompts[index];
    }
}
