using System;
using SplashKitSDK;

namespace Custom_Program
{
    class MushroomBullet : Pea
    {
        public MushroomBullet(Shooter shooter) : base("Mushroom bullet","BulletMushroom.png")
        {
            X = shooter.X + 25;
            Y = shooter.Y - 40;
            Vector2D vel = new Vector2D();
            vel.X = 8;
            vel.Y = 0;
            this.Vel = vel;
            Damage = 5;
            SplashKit.SpriteSetVelocity(this.Sprite, Vel);
            SplashKit.SpriteSetX(this.Sprite, (float)X);
            SplashKit.SpriteSetY(this.Sprite, (float)Y);
        }
    }
}
