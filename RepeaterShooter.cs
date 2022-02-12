using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class RepeaterShooter : Shooter
    {
        public RepeaterShooter(double x, double y) :base("Repeater Shooter", "RepeaterPea.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(this.Sprite, (float)X - 20);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 40);
        }


        public override void Shoot()
        {
            base.Shoot();
            this.ShootingPea.Add(new GreenPea(this.X + 40, this.Y));
            this.ShootingPea.Add(new GreenPea(this.X, this.Y));
        }
    }


}
