using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class InventoryCards
    {
        private List<Card> _invCards;
        public InventoryCards()
        {
            _invCards = new List<Card>();
            _invCards.Add(new CardPeaShooter());
            _invCards.Add(new CardSunFlower());
            _invCards.Add(new CardIceShooter());
            _invCards.Add(new CardRepeater());
            _invCards.Add(new CardPotatoMine());
            _invCards.Add(new CardWallnut());
            _invCards.Add(new CardPuffShroom());
        }
        
        public void DisplayCard()
        {
            for (int i =0; i<_invCards.Count; i++)
            {
                SplashKit.SpriteSetX(_invCards[i].Sprite, 352 + i * 74);
                SplashKit.SpriteSetY(_invCards[i].Sprite, 159 + (i / 8) * 92);
            }
        }

        public List<Card> InvCards
        {
            get
            {
                return _invCards;
            }
        }


    }
}
