using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public class CardPuffShroom : Card
    { 
        public CardPuffShroom() :base("Puff Shroom Card","card_puffshroom.png")
        {
            SunPointsRequired = 25;
        }
    }
}
