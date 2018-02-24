using System;
using System.Collections.Generic;
using System.IO;
using DataModel;
using Foundation;
using Juke.IO;
using MediaPlayer;


namespace JukeIOS.IO
{
    public class SongLoaderIos : SongLoader
    {
        public SongLoaderIos()
        {
        }

        public IList<Song> LoadSongs()
        {
            var songs = new List<Song>();
            /*
            try
            {
                songs.Add(new Song("", "", Environment.CurrentDirectory));

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                var files = Directory.EnumerateFiles("/Users/asbjornandersen/Music", "*.m4a");
            }
            catch (Exception ex)
            {
                songs.Add(new Song("", "", ex.Message));
                Console.WriteLine(ex.Message);
                return songs;
            }*/

            try
            {

                MPMediaQuery mq = new MPMediaQuery();
                var value = NSObject.FromObject(MPMediaType.Music);
                var type = MPMediaItem.MediaTypeProperty;

                var predicate = MPMediaPropertyPredicate.PredicateWithValue(value, type);
                mq.AddFilterPredicate(predicate);

                if (mq.Items != null)
                {
                    foreach (var item in mq.Items)
                    {
                        
                        songs.Add(new Song(item.Artist, item.AlbumTitle, item.Title, item.AlbumTrackNumber+"", ""));
                    }

                } else {
                    songs.Add(new Song("", "", "Restart and try again!"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
                songs.Add(new Song("", "", ex.Message+ " " + ex.StackTrace));
            }


            return songs;
        }
    }
}
