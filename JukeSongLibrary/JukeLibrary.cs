using System;
using System.Collections.Generic;
using JukeApiLibrary;
using JukeApiModel;
using JukeCore.Controllers;

namespace JukeSongLibrary
{
    public class JukeLibrary : SongLibrary
    {
        private LibraryController controller;

        public JukeLibrary(LibraryController controller)
        {
            this.controller = controller;
        }

        public List<Song> GetAllSongs()
        {
            var songData = controller.GetAllSongs();
            var songs = new List<Song>();
            foreach (var data in songData)
            {
                songs.Add(new Song(data.Artist, data.Album, data.Title));
            }

            return songs;
        }
    }
}
