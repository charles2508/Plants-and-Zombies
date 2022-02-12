using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class Pea : GameObject
    {
        private Vector2D _vel;
        private int _damage;
        public Pea(string name, string filename) :base(name,filename)
        {
            _vel = new Vector2D();
            _vel.X = 5;
            _vel.Y = 0;
            this.Vel = _vel;
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
