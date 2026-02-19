using System;

class Song
{
    public string Title;
    public string Artist;
    public double Duration;

    public Song() : this("Unknown", "Unknown", 0.0)
    {
    }

    public Song(string title, string artist) : this(title, artist, 0.0)
    {
    }

    public Song(string title, string artist, double duration)
    {
        Title = string.IsNullOrWhiteSpace(title) ? "Unknown" : title;
        Artist = string.IsNullOrWhiteSpace(artist) ? "Unknown" : artist;
        Duration = duration;
    }

    public void DisplaySong()
    {
        Console.WriteLine("{0,-20} {1,-15} {2,6:F2}", Title, Artist, Duration);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Songs to add: ");
        int size = int.Parse(Console.ReadLine());

        Song[] playlist = new Song[size];

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"\nSong #{i + 1}");

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Artist: ");
            string artist = Console.ReadLine();

            Console.Write("Duration (minutes): ");
            string durationInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title) &&
                string.IsNullOrWhiteSpace(artist) &&
                string.IsNullOrWhiteSpace(durationInput))
            {
                playlist[i] = new Song();
            }
            else if (string.IsNullOrWhiteSpace(durationInput))
            {
                playlist[i] = new Song(title, artist);
            }
            else
            {
                double duration = double.Parse(durationInput);
                playlist[i] = new Song(title, artist, duration);
            }
        }

        Console.WriteLine("\n=== || MY PLAYLIST || ===");
        Console.WriteLine("{0,-20} {1,-15} {2,6}", "Title", "Artist", "Time");
        Console.WriteLine(new string('-', 50));

        double totalDuration = 0;

        foreach (Song song in playlist)
        {
            song.DisplaySong();
            totalDuration += song.Duration;
        }

        double averageDuration = size > 0 ? totalDuration / size : 0;

        Console.WriteLine($"\nTotal Duration: {totalDuration:F2} mins");
        Console.WriteLine($"Average Duration: {averageDuration:F2} mins");
    }
}
