using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class InventoryPanel : GameObject
    {
        public InventoryPanel() :base("Inventory Panel","PanelBackground.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 320);
            SplashKit.SpriteSetY(this.Sprite, 110);
        }


    }
}
