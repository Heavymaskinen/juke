using System;
using Juke.Control;
using JukeIOS.IO;
using UIKit;

namespace JukeIOS
{
    public partial class FirstViewController : UIViewController
    {
        protected FirstViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            JukeController.Instance.LoadLibrary(new SongLoaderIos());

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void UIButton8357_TouchUpInside(UIButton sender)
        {
            if (JukeController.Instance.Browser.Songs.Count > 0){
                var song = JukeController.Instance.Browser.Songs[0];
                JukeController.Instance.Player.PlaySong(song);
                songLabel.Text = song.Name;
            } else {
                songLabel.Text = "Nope";
            }

        }
    }
}
