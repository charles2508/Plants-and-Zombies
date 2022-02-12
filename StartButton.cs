using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class StartButton : Button
    {
        public StartButton() :base("Start Game Button","Startgamebutton.png",1081,633)
        {
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Start Button 1", "Startgamebutton1.png"), "On Hover");
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Start Button 2", "Startgamebutton2.png"), "On Click");
        }
    }
}
