using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class PlayingCard 
    {
        List<Card> _cards;
        //This constructor is used for PickingItemState
        public PlayingCard()
        {
            _cards = new List<Card>(); //The list of cards in PickingItemState is initially empty
        }

        //This constructor is used for IngameState
        public PlayingCard(List<Card> chosenList) :this()
        {
            //The list of cards in IngameState has been selected by player in PickingItemState
            foreach (Card card in chosenList)
            {
                _cards.Add((Card)Activator.CreateInstance(card.GetType()));
            }
        }

        public void DisplayCardsInGame()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                SplashKit.SpriteSetX(_cards[i].Sprite, 20);
                SplashKit.SpriteSetY(_cards[i].Sprite, 50 + i * _cards[i].Sprite.Height);
            }
        }

        public void DisplayChosenCards()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                SplashKit.SpriteSetX(_cards[i].Sprite, 330 + i*65);
                SplashKit.SpriteSetY(_cards[i].Sprite, 5);
            }
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Remove(Card card)
        {
            _cards.Remove(card);
        }

        public List<Card> PlayingCards
        {
            get
            {
                return _cards;
            }
        }
    }
}
