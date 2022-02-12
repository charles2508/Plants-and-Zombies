using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class Card : GameObject
    {
        private int _sunPoints;
        public Card(string name, string filename) : base(name, filename)
        {
        }

        public int SunPointsRequired
        {
            get
            {
                return _sunPoints;
            }
            set
            {
                _sunPoints = value;
            }
        }
    }
}
