using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Baking Sourdough Bread at Home", "Chef Maria", 612);
        video1.AddComment(new Comment("BreadLover22", "This crust looks perfect!"));
        video1.AddComment(new Comment("KitchenNovice", "Finally a recipe that actually works."));
        video1.AddComment(new Comment("SamT", "How long did you let it proof?"));
        video1.AddComment(new Comment("DoughDiva", "Making this tonight, thank you!"));
        videos.Add(video1);

        Video video2 = new Video("Beginner Guitar Chords", "Jake Ellis", 845);
        video2.AddComment(new Comment("MusicMike", "This helped me so much, thanks!"));
        video2.AddComment(new Comment("StrumQueen", "Can you do a video on barre chords next?"));
        video2.AddComment(new Comment("Newbie101", "My fingers hurt but I'm improving."));
        videos.Add(video2);

        Video video3 = new Video("Top 10 Hiking Trails in Utah", "Outdoor Explorers", 1023);
        video3.AddComment(new Comment("TrailBlazer", "Added these to my bucket list!"));
        video3.AddComment(new Comment("CampingCarl", "Number 4 is my favorite, great pick."));
        video3.AddComment(new Comment("NatureNancy", "Is this trail dog friendly?"));
        video3.AddComment(new Comment("WeekendWanderer", "Great video, very informative."));
        videos.Add(video3);

        Video video4 = new Video("Intro to C# Programming", "Code with Casey", 1487);
        video4.AddComment(new Comment("DevDan", "This finally clicked for me, thank you!"));
        video4.AddComment(new Comment("StudentSara", "Could you cover LINQ next?"));
        video4.AddComment(new Comment("ByteBuilder", "Great pacing, easy to follow."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}