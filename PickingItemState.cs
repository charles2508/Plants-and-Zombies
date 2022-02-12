using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    class PickingItemState : GameState
    {
        private Window _gameWindow;
        private PickingItemBackground _pickingBackground;
        private InventoryPanel _inventoryPanel;
        private ItemChosenPanel _itemChosenPanel;
        private PutButton _putButton;
        private StartButton _startButton;
        private ReturnMenuButton _returnMenuButton;
        private InventoryCards _inventoryCards;
        private PlayingCard _playingCard;
        private Card _selectedCard;
        private Card _deselectedCard;
        private List<Music> _musicList;
        private List<Button> _buttons;
        private int _musicIndex;
        public PickingItemState(Window window) :base()
        {
            _gameWindow = window;
            _pickingBackground = new PickingItemBackground();
            _inventoryPanel = new InventoryPanel();
            _itemChosenPanel = new ItemChosenPanel();
            _inventoryCards = new InventoryCards();
            _playingCard = new PlayingCard();
            _putButton = new PutButton();
            _startButton = new StartButton();
            _returnMenuButton = new ReturnMenuButton();
            _musicList = new List<Music>();
            _musicList.Add(SplashKit.LoadMusic("Loonboon", "Loonboon_5.mp3"));
            _musicList.Add(SplashKit.LoadMusic("Moongrains", "Moongrains_6.mp3"));
            _buttons = new List<Button>();
            _buttons.Add(_startButton);
            _buttons.Add(_returnMenuButton);
            _buttons.Add(_putButton);
        }

        public void Next()
        {
            GameContext.GetInstance(_gameWindow).State = new IngameState(_gameWindow, this.PlayingCard.PlayingCards);
        }
        public void Previous()
        {
            GameContext.GetInstance(_gameWindow).State = new MenuState(_gameWindow);
        }

        public void Update()
        {
            SplashKit.ProcessEvents();
            _gameWindow.Clear(Color.White);
             if (!SplashKit.MusicPlaying())
             {
                SplashKit.PlayMusic(_musicList[_musicIndex], 1, 0.3f);
                _musicIndex++;
             }
            if (_musicIndex == _musicList.Count) _musicIndex = 0;
            _inventoryCards.DisplayCard();
            _playingCard.DisplayChosenCards();
            if (SplashKit.MouseClicked(MouseButton.LeftButton)) //Test
            {
                Point2D point = new Point2D();
                point.X = SplashKit.MouseX();
                point.Y = SplashKit.MouseY();
                if ((point.X >= 352 && point.X <= 938) && (point.Y >= 159 && point.Y <= 248))
                {
                    PickCard(point);
                }
                else if ((point.X >= 542 && point.X <= 760) && (point.Y >= 651 && point.Y <= 687))
                {
                    if (_selectedCard != null)
                    {
                        _playingCard.Add(_selectedCard);
                        _selectedCard = null;
                    }
                } 
                else if ((point.X >= 331 && point.X <= 785) && (point.Y >= 6 && point.Y <= 91))
                {
                    DeselectCard(point);
                } 
                else if (SplashKit.SpritePointCollision(_putButton.Sprite,point))
                {
                    if (_deselectedCard != null)
                    {
                        _playingCard.Remove(_deselectedCard);
                        _deselectedCard = null;   
                    }
                }
            
                
           
            }
            SplashKit.DrawAllSprites();
            SplashKit.UpdateAllSprites();
            foreach (Button btn in _buttons)
            {
                btn.CheckButtonState();
                btn.Draw();
                if (btn.GetType().Equals(typeof(ReturnMenuButton)))
                {
                    if (btn.OnClickingTime >= 15)
                    {
                        FreeAllSprites();
                        FreeAllMusics();
                        Previous();
                        break;
                    }
                }
                if (btn.GetType().Equals(typeof(StartButton)))
                {
                    if (btn.OnClickingTime >= 15)
                    {
                        btn.OnClickingTime = 0;
                        if (PlayingCard.PlayingCards.Count == 6 || PlayingCard.PlayingCards.Count == 7)
                        {
                            FreeAllSprites();
                            FreeAllMusics();
                            Next();
                            break;
                        }
                    }
                }
            }
            
            _gameWindow.Refresh(60);
        }

        public void PickCard(Point2D point)
        {

            foreach (Card card in _inventoryCards.InvCards)
            {
                if (SplashKit.SpritePointCollision(card.Sprite, point))
                {
                    _selectedCard = card;
                }
            }
        }

        public void DeselectCard(Point2D point)
        {
            foreach (Card card in _playingCard.PlayingCards)
            {
                if (SplashKit.SpritePointCollision(card.Sprite, point)) _deselectedCard = card;
            }
        }

        public StartButton StartButton
        {
            get
            {
                return _startButton;
            }
        }

        public ReturnMenuButton ReturnMenuButton
        {
            get
            {
                return _returnMenuButton;
            }
        }

        public PlayingCard PlayingCard
        {
            get
            {
                return _playingCard;
            }
        }

        public void FreeAllSprites()
        {
            SplashKit.FreeAllSprites();
            for (int i = 0; i < _inventoryCards.InvCards.Count; i++) _inventoryCards.InvCards.Remove(_inventoryCards.InvCards[i]);
        }

        public void FreeAllMusics()
        {
            SplashKit.FreeAllMusic();
            for (int i = 0; i < _musicList.Count; i++) _musicList.Remove(_musicList[i]);
        }

    }
}
