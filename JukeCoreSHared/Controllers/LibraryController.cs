using System;
using System.Collections.Generic;
using JukeCore.Model;
using JukeCoreShared.Dto;

namespace JukeCore.Controllers
{
    public class LibraryController
    {
        private Library library;

        public LibraryController() 
        {
            library = new Library();
        }

        public int GetSongCount()
        {
            return library.Count;
        }

        public void LoadSongs()
        {
            library.LoadSongs(AbstractSongReaderFactory.Instance.Create());
        }

        public List<string> GetSongsByArtist(string artistName)
        {
            var songs = library.GetSongsByArtist(artistName);
            var titles = new List<string>();
            foreach (var song in songs) {
                titles.Add(song.Title);
            }

            return titles;
        }

        public List<SongData> GetAllSongs()
        {
            var songData = new List<SongData>();
            foreach (var song in library.GetSongs()) {
                songData.Add(new SongData(song.Artist, "", song.Title));
            }

            return songData;
        }
    }
}
