using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class PuffShroom : Shooter
    {
        //Layer interface
        private int _sleepingTime;
        public PuffShroom(double x, double y) :base("PuffShroom Sleep", "PuffShroomSleep.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteAddLayer(this.Sprite,new Bitmap("PuffSchroom", "PuffShroom.png"), "PuffShroom Wake Up");
            SplashKit.SpriteSetX(this.Sprite, (float)X - 20);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 60);
        }

        public void AdjustLayer()
        {
            if (_sleepingTime >= 627)
            {
                SplashKit.SpriteHideLayer(this.Sprite, 0);
                SplashKit.SpriteShowLayer(this.Sprite, 1);
            }
        }

        public void Shoot(Zombie zombie)
        {
            if (_sleepingTime >= 627 && SplashKit.PointPointDistance(SplashKit.CenterPoint(this.Sprite), SplashKit.CenterPoint(this.Sprite)) < 400)
            {
                MushroomBullet mushroombullet = new MushroomBullet(this);
                base.Shoot();
                this.ShootingPea.Add(mushroombullet);
            }
        }

        public int SleepingTime
        {
            get
            {
                return _sleepingTime;
            }
            set
            {
                _sleepingTime = value;
            }
        }

    }
}
