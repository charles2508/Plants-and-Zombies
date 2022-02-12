using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace Custom_Program
{
    public enum ButtonState
    {
        Normal,
        Highlighted,
        Pressed
    }

    public abstract class Button : GameObject
    {
        private ButtonState _bttnState;
        private int _onClickingTime;
        private bool _onClicking;
        private string _name;
        public Button(string name, string filename, int X, int Y) : base(name, filename)
        {
            this._name = name;
            SplashKit.SpriteSetX(this.Sprite, X);
            SplashKit.SpriteSetY(this.Sprite, Y);
            _bttnState = ButtonState.Normal;
            _onClickingTime = 0;
            _onClicking = false;
        }
        //Draw button based on different states
        public void Draw()
        {
            if (_bttnState == ButtonState.Normal) NormalButton();
            if (_bttnState == ButtonState.Highlighted) OnHoverButton();
            if (_bttnState == ButtonState.Pressed)
            {
                OnClickButton();
                _onClickingTime++;
            }
        }

        // Check the current state of the button
        public virtual void CheckButtonState()
        {
            if (!_onClicking)
            {
                _bttnState = ButtonState.Normal;
            }
            if (OnHover() && !_onClicking)
            {
                _bttnState = ButtonState.Highlighted;
            }
            if (OnClick())
            {
                _onClicking = true;
            }
            if (_onClicking)
            {
                _bttnState = ButtonState.Pressed;
                if (_onClickingTime == 14) _onClicking = false;
            }
        }

        //Check whether the buton is being hovered on or not
        private bool OnHover()
        {
            return SplashKit.SpritePointCollision(this.Sprite, SplashKit.MousePosition());
        }
        //Check whether the button is being clicked or not
        private bool OnClick()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D point = new Point2D();
                point.X = SplashKit.MouseX();
                point.Y = SplashKit.MouseY();
                return SplashKit.SpritePointCollision(this.Sprite, point);
            }
            return false;
        }

        public int OnClickingTime
        {
            get
            {
                return _onClickingTime;
            }
            set
            {
                _onClickingTime = 0;
            }
        }

        public void NormalButton()
        {
            SplashKit.SpriteHideLayer(this.Sprite, 1);
            SplashKit.SpriteHideLayer(this.Sprite, 2);
            SplashKit.SpriteShowLayer(this.Sprite, 0);
        }

        public void OnHoverButton()
        {
            SplashKit.SpriteHideLayer(this.Sprite, 0);
            SplashKit.SpriteHideLayer(this.Sprite, 2);
            SplashKit.SpriteShowLayer(this.Sprite, 1);
        }

        public void OnClickButton()
        {
            SplashKit.SpriteHideLayer(this.Sprite, 0);
            SplashKit.SpriteHideLayer(this.Sprite, 1);
            SplashKit.SpriteShowLayer(this.Sprite, 2);
        }
    }
}
