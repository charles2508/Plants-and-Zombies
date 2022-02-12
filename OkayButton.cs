using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class OkayButton : Button
    {
        public OkayButton() :base("Okay Button", "OkayButton.png", 630,500)
        {
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Okay Button 1", "OkayButton1.png"), "On Hover");
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Okay Button Button 2", "OkayButton2.png"), "On Click");
        }
    }
}
