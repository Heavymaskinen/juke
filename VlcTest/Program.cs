using System;
using System.IO;
using Vlc.DotNet.Core;

namespace VlcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                var info = new DirectoryInfo(Directory.GetCurrentDirectory()+"//vlc");
                Console.WriteLine(info.FullName);
                var player = new VlcMediaPlayer(info);

                player.SetMedia(Directory.GetCurrentDirectory()+"//September.m4a");
                player.Play();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
