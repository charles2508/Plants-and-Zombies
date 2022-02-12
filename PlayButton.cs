using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class PlayButton : Button
    {
        public PlayButton() :base("Play Button","Playbutton.png",560,600)
        {
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Play Button 1", "Playbutton1.png"), "On Hover");
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Play Button 2", "Playbutton2.png"), "On Click");
        }


    }
}
