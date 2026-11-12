
using System;
using System.Linq;

public class Word
{
    // Private fields protect the word's information.
    private string _text;
    private bool _isHidden;

    // A new word starts in the visible state.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hides this word.
    public void Hide()
    {
        _isHidden = true;
    }

    // Makes this word visible again.
    public void Show()
    {
        _isHidden = false;
    }

    // Checks whether this word is hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the original word or its hidden version.
    // Punctuation is preserved, and each letter becomes an underscore.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string(
                _text.Select(character =>
                    char.IsLetter(character) ? '_' : character
                ).ToArray()
            );
        }

        return _text;
    }
}
