using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class PotatoMine : Item
    {
        private int _initialTime;
        private int _explodingTime;
        private bool _exploding;
        private int _damage;
        public PotatoMine(double x, double y) :base("Potato Mine Init","PotatoMineInit.png")
        {
            X = x;
            Y = y;
            _damage = 100; //Can be an interface with shooter
            Exploding = false;
            SplashKit.SpriteSetX(this.Sprite, (float)X - 20);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 40);
            this.Sprite.AddLayer(new Bitmap("Potato Mine", "PotatoMine.png"), "Potato Mine");
            this.Sprite.AddLayer(new Bitmap("Potato Mine Explode", "PotatoMineExplode.png"), "Exploded");
        }

        public int InitialTime
        {
            get
            {
                return _initialTime;
            }
        }

        public int ExplodingTime
        {
            get
            {
                return _explodingTime;
            }
        }

                
        public bool Exploding
        {
            get
            {
                return _exploding;
            }
            set
            {
                _exploding = value;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
        }
        public void AdjustingState()
        {
            _initialTime++;
            if (Exploding)
            {
                _explodingTime++;
            }
            AdjustLayer();
        }

        private void AdjustLayer()
        {
            if (Exploding)
            {
                SplashKit.SpriteHideLayer(Sprite, 1);
                SplashKit.SpriteShowLayer(Sprite, 2);
            } else if (InitialTime >= 900)
            {
                SplashKit.SpriteHideLayer(Sprite, 0);
                SplashKit.SpriteShowLayer(Sprite, 1);
            }
        }

        public override void BeAttacked(Zombie zombie)
        {
            
        }
    }
}
