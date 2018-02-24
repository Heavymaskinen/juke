using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juke.IO
{
    /// <summary>
    /// Interface for SongCatalogue - used to wrap the Library class.
    /// </summary>
    public interface LoadHandler
    {
        event EventHandler LibraryUpdated;

        void LoadSongs(SongLoader loader);
        void LoadSongs(AsyncSongLoader loader);
    }
}
