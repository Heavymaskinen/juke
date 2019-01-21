using System;
using System.Collections.Generic;


namespace JukeCore.Model
{
    public class Library
    {
        private List<Song> songs;

        public int Count => songs.Count;

        public Library()
        {
            
            songs = new List<Song>();
        }

        internal void LoadSongs(SongReader songReader)
        {
            songs = songReader.GetSongs();
        }

        internal List<Song> GetSongsByArtist(string artistName)
        {
            var songsByArtist = new List<Song>();
            foreach (var song in songs) {
                if (song.Artist == artistName) {
                    songsByArtist.Add(song);
                }
            }

            return songsByArtist;    
        }

        internal IEnumerable<Song> GetSongs() {
            return songs;
        }
    }
}
