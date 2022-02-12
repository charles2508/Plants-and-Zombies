using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class ItemChosenPanel : GameObject
    {
        public ItemChosenPanel() :base("ItemChosenPanel","ItemChosen.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 324);
            SplashKit.SpriteSetY(this.Sprite, 0);
        }
    }
}
