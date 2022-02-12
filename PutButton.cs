using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class PutButton : Button
    {
        public PutButton() :base("Put Button", "Putbutton.png", 795, 64)
        {
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Put Button 1", "Putbutton1.png"), "On Hover");
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Put Button 2", "Putbutton2.png"), "On Click");
        }

        public override void CheckButtonState()
        {
            base.CheckButtonState();
            if (this.OnClickingTime >= 15)
            {
                this.OnClickingTime = 0;
            }
        }
    }
}
