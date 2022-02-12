using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class Defeat : GameObject
    {
        public Defeat() : base("Defeat", "Lose.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 380);
            SplashKit.SpriteSetY(this.Sprite, 110);
        }
    }
}
