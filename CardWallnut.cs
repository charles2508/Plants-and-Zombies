using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public class CardWallnut : Card
    {
        public CardWallnut() : base("Wallnut Card", "card_wallnut.png")
        {
            SunPointsRequired = 50;
        }
    }
}
