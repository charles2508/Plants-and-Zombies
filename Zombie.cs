using System;
using SplashKitSDK;

namespace Custom_Program
{
    public abstract class Zombie : GameObject
    {
        private int _health;
        private Vector2D _vel;
        private int _damage;
        private bool _eating;
        private int _row;
        private int _swallowingTime;
        private int _slowingTime;
        private bool _getSlow;
        private bool _damagedByMine;
        public Zombie(string name, string filename) : base(name, filename)
        {
            _vel = new Vector2D();
            Eating = false;
            _getSlow = false;
            _damagedByMine = false;
        }


        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public void BeAttacked(Pea pea)
        {
            if (pea.GetType().Equals(typeof(IcePea)))
            {
                _slowingTime = 60;
            }
            this.Health -= pea.Damage;
        }

        public void AdjustVelocity()
        {
            if (this.Eating)
            {
                SplashKit.SpriteSetDx(this.Sprite, 0);
            }
            else if (_slowingTime > 0) SplashKit.SpriteSetDx(this.Sprite, -0.25f);
            else SplashKit.SpriteSetDx(this.Sprite, -0.5f);
        }

        public void DecreaseSlowingTime()
        {
            if (_slowingTime > 0)
            {
                _slowingTime--;
            }
        }

        public void IncreaseSwallowingTime()
        {
            _swallowingTime++;
        }

        public bool DamagedByMine
        {
            get
            {
                return _damagedByMine;
            }
            set
            {
                _damagedByMine = value;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }

        public abstract void AdjustLayer();
        public bool Eating
        {
            get
            {
                return _eating;
            }
            set
            {
                _eating = value;
            }
        }

        public bool GetSlow
        {
            get
            {
                return _getSlow;
            }
            set
            {
                _getSlow = value;
            }
        }

        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }

        public int SwallowingTime
        {
            get
            {
                return _swallowingTime;
            }
            set
            {
                _swallowingTime = value;
            }
        }

        public Vector2D Vel
        {
            get
            {
                return _vel;
            }
            set
            {
                _vel = value;
            }
        }
    }
}
