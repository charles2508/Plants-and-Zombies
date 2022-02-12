using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    class CardPeaShooter : Card
    {
        public CardPeaShooter() : base("Pea Shooter Card", "card_peashooter.png")
        {
            SunPointsRequired = 100;
        }
    }
}
