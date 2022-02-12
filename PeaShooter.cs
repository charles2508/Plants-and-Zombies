using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    class PeaShooter : Shooter
    {
        public PeaShooter(double x, double y) : base("Pea Shooter", "Peashooter_1.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(this.Sprite,(float)X - 20);
            SplashKit.SpriteSetY(this.Sprite,(float)Y - 40);
        }

        public override void Shoot()
        {
            GreenPea greenPea = new GreenPea(this.X, this.Y);
            base.Shoot();
            this.ShootingPea.Add(greenPea);
        }
    }
}
