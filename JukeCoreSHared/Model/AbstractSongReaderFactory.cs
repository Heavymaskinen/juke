using System;
using System.Collections.Generic;
namespace JukeCore.Model
{
    public abstract class AbstractSongReaderFactory
    {
        public static AbstractSongReaderFactory Instance
        {
            get; set;
        }

        public abstract SongReader Create();
    }
}
