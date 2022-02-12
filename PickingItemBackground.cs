using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class PickingItemBackground : GameObject
    {
        public PickingItemBackground() :base("Picking Item Background","pickingitembackground.jpg")
        {
            SplashKit.SpriteSetX(this.Sprite, 0);
            SplashKit.SpriteSetY(this.Sprite, 0);
        }
    }
}
