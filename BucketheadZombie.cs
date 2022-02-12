using System;
using SplashKitSDK;


namespace Custom_Program
{
    public class BucketheadZombie : Zombie
    {
        public BucketheadZombie() :base("Buckethead zombie", "Bucketheadzombie.png")
        {
            int row = SplashKit.Rnd(0, 5);
            if (row == 4) Y = 120 + 97 * row;
            else if (row == 3) Y = 110 + 97 * row;
            else if (row == 0) Y = 80;
            else if (row == 1) Y = 90 + 97 * row;
            else Y = 100 + 97 * row;
            X = SplashKit.ScreenWidth() + 50;
            Health = 360;
            Vector2D _vel = new Vector2D();
            _vel.X = -0.5;
            _vel.Y = 0;
            Vel = _vel;
            Damage = 25;
            Row = row;
            SplashKit.SpriteSetX(this.Sprite, (float)X);
            SplashKit.SpriteSetY(this.Sprite, (float)Y);
            SplashKit.SpriteSetVelocity(this.Sprite, Vel);
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("BucketHead Attack", "BucketheadZombieAttack.png"), "BucketHead Attack");
            SplashKit.SpriteAddLayer(this.Sprite, new Bitmap("Normal Zombie", "normalzombie.png"), "Normal Zombie");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Normal Zombie Attack", "NormalZombieAttack.png"), "Attack");
        }

        public override void AdjustLayer()
        {
            if (this.Health > 100 && this.Eating)
            {
                SplashKit.SpriteHideLayer(this.Sprite, 0);
                SplashKit.SpriteHideLayer(this.Sprite, 2);
                SplashKit.SpriteHideLayer(this.Sprite, 3);
                SplashKit.SpriteShowLayer(this.Sprite, 1);
            }
            else if (this.Health > 100 && !this.Eating)
            {
                SplashKit.SpriteHideLayer(this.Sprite, 1);
                SplashKit.SpriteHideLayer(this.Sprite, 2);
                SplashKit.SpriteHideLayer(this.Sprite, 3);
                SplashKit.SpriteShowLayer(this.Sprite, 0);
            }
            else if (this.Health <= 100 && this.Eating)
            {
                SplashKit.SpriteHideLayer(this.Sprite, 1);
                SplashKit.SpriteHideLayer(this.Sprite, 0);
                SplashKit.SpriteHideLayer(this.Sprite, 2);
                SplashKit.SpriteShowLayer(this.Sprite, 3);
            }
            else if (this.Health <= 100 && !this.Eating)
            {
                SplashKit.SpriteHideLayer(this.Sprite, 1);
                SplashKit.SpriteHideLayer(this.Sprite, 0);
                SplashKit.SpriteHideLayer(this.Sprite, 3);
                SplashKit.SpriteShowLayer(this.Sprite, 2);
            }
        }
    }
}
