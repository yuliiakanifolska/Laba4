using System;
using System.Collections.Generic;
namespace task_2
{
    class MusicComposition
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int DurationInSeconds { get; set; }
        public string Genre { get; set; }

        public MusicComposition(string title, string artist, int durationInSeconds, string genre)
        {
            Title = title;
            Artist = artist;
            DurationInSeconds = durationInSeconds;
            Genre = genre;
        }

        public TimeSpan GetLength()
        {
            return TimeSpan.FromSeconds(DurationInSeconds);
        }
    }
}
