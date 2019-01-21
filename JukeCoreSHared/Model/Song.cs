namespace JukeCore.Model
{
    public class Song
    {
        public Song(string artistName, string title)
        {
            Artist = artistName;
            Title = title;
        }

        public string Artist { get; set; }
        public string Title { get; set; }

    }
}
