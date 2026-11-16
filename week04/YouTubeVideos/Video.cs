
using System.Collections.Generic;

// The Video class stores video details and a list of comments.
public class Video
{
    // Private fields store the video's information.
    private string _title;
    private string _author;
    private int _length;

    // Each video contains a list of Comment objects.
    private List<Comment> _comments;

    // Constructor initializes the video details and comment list.
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;

        // Start with an empty list of comments.
        _comments = new List<Comment>();
    }

    // Adds a Comment object to this video's comment list.
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns the video's title.
    public string GetTitle()
    {
        return _title;
    }

    // Returns the video's author.
    public string GetAuthor()
    {
        return _author;
    }

    // Returns the video's length in seconds.
    public int GetLength()
    {
        return _length;
    }

    // Returns the number of comments stored in the list.
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Returns the list of comments belonging to this video.
    public List<Comment> GetComments()
    {
        return _comments;
    }
}
