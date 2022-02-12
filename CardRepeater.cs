using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class CardRepeater : Card
    {
        public CardRepeater() : base("Repeater Card","card_repeaterpea.png")
        {
            SunPointsRequired = 200;
        }
    }
}
