using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class GameObject
    {
        private Bitmap _bitmap;
        private Sprite _sprite;
        private double _x;
        private double _y;
        public GameObject(string name, string filename)
        {
            _bitmap = new Bitmap(name, filename);
            _sprite = SplashKit.CreateSprite(_bitmap);
        }

        public Bitmap Bitmap
        {
            get
            {
                return _bitmap;
            }
            set
            {
                _bitmap = value;
            }
        }

        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
            set
            {
                _sprite = value;
            }
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

    }
}
