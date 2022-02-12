using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    class IcePea : Pea
    {
        public IcePea(Shooter shooter) :base("Ice Pea", "peaice.png")
        {
            X = shooter.X + 25;
            Y = shooter.Y - 40;
            Damage = 10;
            SplashKit.SpriteSetVelocity(this.Sprite, Vel);
            SplashKit.SpriteSetX(this.Sprite, (float)X);
            SplashKit.SpriteSetY(this.Sprite, (float)Y);
        }
    }
}
