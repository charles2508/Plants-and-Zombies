using System;
using SplashKitSDK;

namespace Custom_Program
{
    public class CardPotatoMine : Card
    {
        public CardPotatoMine() :base("PotatoMine Card", "card_potatomine.png")
        {
            SunPointsRequired = 25;
        }
    }
}
