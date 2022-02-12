using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class Menu : GameObject
    {
        public Menu() :base("Main Menu","MainMenu.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 0);
            SplashKit.SpriteSetY(this.Sprite, 0);
        }

    }
}
