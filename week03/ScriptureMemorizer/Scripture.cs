
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    // Private fields keep the scripture's internal data protected.
    private Reference _reference;
    private List<Word> _words;

    // Random generator used to select words to hide.
    private static readonly Random _random = new Random();

    // The constructor receives a reference and the scripture text.
    // It creates the Word objects internally.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the scripture into individual words.
        string[] wordTexts = text.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        // Create a Word object for each word.
        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Hides a requested number of words that are not already hidden.
    public void HideRandomWords(int numberToHide)
    {
        // Get only the words that are still visible.
        List<Word> availableWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        // Hide words until the requested number is reached
        // or no visible words remain.
        int wordsToHide = Math.Min(numberToHide, availableWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            // Select a random word from the available words.
            int randomIndex = _random.Next(availableWords.Count);

            // Hide the selected word.
            availableWords[randomIndex].Hide();

            // Remove it so it cannot be selected again in this round.
            availableWords.RemoveAt(randomIndex);
        }
    }

    // Returns the reference and all words as one display string.
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}: {string.Join(" ", displayWords)}";
    }

    // Checks whether every word has been hidden.
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    // Returns the number of words currently hidden.
    public int GetHiddenWordCount()
    {
        return _words.Count(word => word.IsHidden());
    }

    // Returns the total number of words in the scripture.
    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    // Calculates the percentage of words already hidden.
    public double GetProgressPercentage()
    {
        if (_words.Count == 0)
        {
            return 100;
        }

        return (double)GetHiddenWordCount() / _words.Count * 100;
    }
}
