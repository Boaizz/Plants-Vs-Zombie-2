using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram.Buttons
{
    public enum ButtonState
    {
        Normal,
        Hover,
        Click
    }

    public abstract class Button : GameObject
    {
        private ButtonState _buttonState;
        private int _isClickedTime;
        private bool _isClicked;
        private string _name;
        public Button(string name, string filename, int X, int Y) : base(name, filename)
        {
            _name = name;
            _buttonState = ButtonState.Normal;
            _isClickedTime = 0;
            _isClicked = false;
            SplashKit.SpriteSetX(Sprite, X);
            SplashKit.SpriteSetY(Sprite, Y);
        }
        public int IsClickedTime
        {
            get
            {
                return _isClickedTime;
            }
            set
            {
                _isClickedTime = 0;
            }
        }
        public void Draw()
        {
            if (_buttonState == ButtonState.Normal) NormalButton();
            if (_buttonState == ButtonState.Hover) HoverButton();
            if (_buttonState == ButtonState.Click)
            {
                ClickButton();
                _isClickedTime++;
            }
        }


        public virtual void CheckButtonState()
        {
            if (!_isClicked)
            {
                _buttonState = ButtonState.Normal;
            }
            if (IsHovered() && !_isClicked)
            {
                _buttonState = ButtonState.Hover;
            }
            if (IsClicked())
            {
                _isClicked = true;
            }
            if (_isClicked)
            {
                _buttonState = ButtonState.Click;
                if (_isClickedTime == 14)
                {
                    _isClicked = false;
                }

            }
        }


        private bool IsHovered()
        {
            return SplashKit.SpritePointCollision(Sprite, SplashKit.MousePosition());
        }

        private bool IsClicked()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D point = new Point2D();
                point.X = SplashKit.MouseX();
                point.Y = SplashKit.MouseY();
                return SplashKit.SpritePointCollision(Sprite, point);
            }
            else
            {
                return false;
            }
        }



        public void NormalButton()
        {
            SplashKit.SpriteHideLayer(Sprite, 1);
            SplashKit.SpriteHideLayer(Sprite, 2);
            SplashKit.SpriteShowLayer(Sprite, 0);
        }

        public void HoverButton()
        {
            SplashKit.SpriteHideLayer(Sprite, 0);
            SplashKit.SpriteHideLayer(Sprite, 2);
            SplashKit.SpriteShowLayer(Sprite, 1);
        }

        public void ClickButton()
        {
            SplashKit.SpriteHideLayer(Sprite, 0);
            SplashKit.SpriteHideLayer(Sprite, 1);
            SplashKit.SpriteShowLayer(Sprite, 2);
        }
    }
}
