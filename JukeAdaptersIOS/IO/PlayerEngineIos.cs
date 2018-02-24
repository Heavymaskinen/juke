using System;
using AVFoundation;
using DataModel;
using Foundation;
using Juke.Core;
using MediaPlayer;

namespace JukeIOS.IO
{
    public class PlayerEngineIos : PlayerEngine
    {

        public PlayerEngineIos()
        {
        }

        public override void Play(Song song)
        {
         

            var p = MPMusicPlayerController.SystemMusicPlayer;
            p.Stop();

            p.SetQueue(new string[] {song.Name});
            p.Play();
        }

        public override void Stop()
        {
            SignalFinished();
        }
    }
}
