using System;
using SplashKitSDK;

namespace Custom_Program
{
    class GreenPea : Pea
    {
        public GreenPea(double x, double y) : base("Green Pea", "pea.png")
        {
            X = x + 25;
            Y = y - 40;
            Damage = 20;
            SplashKit.SpriteSetVelocity(this.Sprite, Vel);
            SplashKit.SpriteSetX(this.Sprite, (float)X);
            SplashKit.SpriteSetY(this.Sprite, (float)Y);
        }
    }
}
