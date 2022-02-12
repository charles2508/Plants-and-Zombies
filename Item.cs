using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public abstract class Item : GameObject
    {
        private int _health;
        private CentrePoint _centrePoint;
        public Item(string name, string filename) :base(name,filename)
        {
            _health = 100;
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

        public int Row
        {
            get
            {
                return (int)Math.Ceiling((Y-145)/110);
            }
        }

        public CentrePoint CentrePoint
        {
            get
            {
                return _centrePoint;
            }
            set
            {
                _centrePoint = value;
            }
        }

        public abstract void BeAttacked(Zombie zombie);
    }
}
