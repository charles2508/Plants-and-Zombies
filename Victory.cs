using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class Victory : GameObject
    {
        public Victory() :base("Victory Title","victory.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 380);
            SplashKit.SpriteSetY(this.Sprite, 110);
        }
    }
}
