
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the first video.
        Video video1 = new Video(
            "How to Build a Successful Career in Technology",
            "Tech Academy",
            720
        );

        // Add three comments to the first video.
        video1.AddComment(new Comment(
            "James Rex Ovie",
            "This video has given me useful ideas for my career."
        ));

        video1.AddComment(new Comment(
            "Omoefe Favour Esther",
            "I really enjoyed the practical advice. Thank you!"
        ));

        video1.AddComment(new Comment(
            "Michael Brown",
            "Very informative and easy to understand."
        ));

        // Create the second video.
        Video video2 = new Video(
            "Five Programming Skills Every Beginner Should Learn",
            "Code With Confidence",
            950
        );

        // Add three comments to the second video.
        video2.AddComment(new Comment(
            "David Smith",
            "Learning C# has become easier with explanations like this."
        ));

        video2.AddComment(new Comment(
            "Grace Williams",
            "The examples were very helpful. Great presentation!"
        ));

        video2.AddComment(new Comment(
            "Daniel Okafor",
            "I will definitely practise these programming skills."
        ));

        // Create the third video.
        Video video3 = new Video(
            "The Importance of Personal Development",
            "Growth Mindset Channel",
            840
        );

        // Add three comments to the third video.
        video3.AddComment(new Comment(
            "Esther Adams",
            "Personal development is important for everyone."
        ));

        video3.AddComment(new Comment(
            "Samuel James",
            "This message has motivated me to keep improving."
        ));

        video3.AddComment(new Comment(
            "Linda White",
            "Excellent content. I learned something valuable today."
        ));

        // Store all three Video objects in a list.
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display the information for each video.
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("VIDEO INFORMATION");
            Console.WriteLine("========================================");

            // Display the video's basic information.
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");

            // Display the number of comments using the Video method.
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nCOMMENTS");
            Console.WriteLine("----------------------------------------");

            // Display every comment belonging to this video.
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"Commenter: {comment.GetCommenterName()}");
                Console.WriteLine($"Comment: {comment.GetCommentText()}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("========================================");
        Console.WriteLine("END OF VIDEO REPORT");
        Console.WriteLine("========================================");
    }
}
