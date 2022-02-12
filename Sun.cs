using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class Sun : GameObject
    {
        private int _appearTime;
        public Sun(SunFlower sunflower) : this(sunflower.X, sunflower.Y)
        {
           
        }

        public Sun(double x, double y) : base("Single Sun", "sun.png")
        {
            X = x;
            Y = y;
            _appearTime = 0;
            SplashKit.SpriteSetX(this.Sprite, (float)X - 10);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 30);
        }

        public int AppearTime
        {
            get
            {
                return _appearTime;
            }
        }

        public void Count()
        {
            _appearTime++;
        }

        public bool IsAt(Point2D pt)
        {
            if (SplashKit.SpritePointCollision(this.Sprite,pt))
            {
                return true;
            }
            return false;
        }
    }
}
