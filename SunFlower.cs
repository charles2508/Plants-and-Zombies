using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class SunFlower : Item
    {
        private int _waitingTime;
        private int _bloomingTime;
        public SunFlower(double x, double y) : base("Sunflower", "sunflower.png")
        {
            X = x;
            Y = y;
            SplashKit.SpriteSetX(this.Sprite, (float)X - 15);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 35);
            _waitingTime = 0;
            _bloomingTime = SplashKit.Rnd(500, 700);
        }

        public int WaitingTime
        {
            get
            {
                return _waitingTime;
            }
        }

        public int BloomingTime
        {
            get
            {
                return _bloomingTime;
            }
        }

        public void Count()
        {
            _waitingTime++;
        }

        public void Reset()
        {
            _waitingTime = 0;
        }

        public override void BeAttacked(Zombie zombie)
        {
            this.Health -= zombie.Damage;
        }
    }
}
