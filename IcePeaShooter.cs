using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class IcePeaShooter : Shooter
    {
        public IcePeaShooter(double x, double y) :base("Ice Shooter","icepeashoter.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(this.Sprite, (float)X - 20);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 40);
        }

        public override void Shoot()
        {
            IcePea icepea = new IcePea(this);
            base.Shoot();
            this.ShootingPea.Add(icepea);
        }
    }
}
