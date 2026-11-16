
using System;

// The Comment class stores information about one comment.
public class Comment
{
    // Private fields hold the commenter's name and comment text.
    private string _commenterName;
    private string _commentText;

    // Constructor sets the values when a Comment object is created.
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Returns the name of the person who made the comment.
    public string GetCommenterName()
    {
        return _commenterName;
    }

    // Returns the actual comment.
    public string GetCommentText()
    {
        return _commentText;
    }
}
