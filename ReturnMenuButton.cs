using SplashKitSDK;

namespace Custom_Program
{
    public class ReturnMenuButton : Button
    {
        public ReturnMenuButton() : base("Return Menu button", "Returnmenu.png", 0,633)
        {
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Return Menu Button 1", "Returnmenu1.png"),"On Hover");
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Return Menu Button 2", "Returnmenu2.png"), "On Click");
        }
    }
}
