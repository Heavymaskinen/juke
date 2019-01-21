using System;
namespace JukeCoreShared.Dto
{
    public class SongData
    {
        public SongData(string artist, string album, string title)
        {
            Artist = artist;
            Album = album;
            Title = title;
        }
        public string Artist { get; private set; }
        public string Title { get; private set; }
        public string Album { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is SongData) {
                return ((SongData)obj).ToString().Equals(ToString());
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<string>(ToString());
        }

        public override string ToString()
        {
            return Artist+";"+Album+";"+Title;
        }
    }
}
