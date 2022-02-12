using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Custom_Program
{
    public class MenuState : GameState
    {
        private Menu _mainMenu;
        private PlayButton _playButton;
        private Bitmap _menuImage;
        private Sprite _menuImageS;
        private Window _gameWindow;
        private Music _music;
        private Button _button;
        public MenuState(Window gameWindow) :base()
        {
            _mainMenu = new Menu();
            _playButton = new PlayButton();
            _gameWindow = gameWindow;
            _music = SplashKit.LoadMusic("CrazyDaveIntroTheme", "CrazyDaveIntroTheme_2.mp3");
            _menuImage = new Bitmap("menu Image", "menuimage.png");
            _menuImageS = SplashKit.CreateSprite(_menuImage);
            _button = new PlayButton();
            SplashKit.SpriteSetX(_menuImageS, 420);
            SplashKit.SpriteSetY(_menuImageS, 60);
        }
        public void Next()
        {
            GameContext.GetInstance(_gameWindow).State = new PickingItemState(_gameWindow);
        }
        public void Previous()
        {
            
        }

        public void Update()
        {
            SplashKit.ProcessEvents();
            _gameWindow.Clear(Color.White);
            if (!SplashKit.MusicPlaying()) SplashKit.PlayMusic(_music,1,0.3f);
            SplashKit.DrawAllSprites();
            SplashKit.UpdateAllSprites();
            _button.CheckButtonState(); 
            _button.Draw();
            if (_button.OnClickingTime >= 15)
            {
                FreeAllSprites();
                FreeAllMusics();
                Next();
            }
            _gameWindow.Refresh(60);
        }

        public PlayButton PlayButton
        {
            get
            {
                return _playButton;
            }
        }

        public void FreeAllSprites()
        {
            SplashKit.FreeAllSprites();
        }

        public void FreeAllMusics()
        {
            SplashKit.FreeAllMusic();
        }
    }
}
