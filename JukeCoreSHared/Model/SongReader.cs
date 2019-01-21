using System.Collections.Generic;

namespace JukeCore.Model
{
    public interface SongReader
    {
        List<Song> GetSongs();
    }
}
