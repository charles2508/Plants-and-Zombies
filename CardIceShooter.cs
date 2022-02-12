using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    class CardIceShooter : Card
    {
        public CardIceShooter() : base("Ice Shooter Card", "card_snowpea.png")
        {
            SunPointsRequired = 175;
        }


    }
}
