using CustomProgram.Plants;
using SplashKitSDK;

namespace CustomProgram
{
    public class Sun : GameObject
    {
        private int _existTime;
        public Sun(SunFlower sunflower) : this(sunflower.X, sunflower.Y)
        {
           
        }

        public Sun(double x, double y) : base("Single Sun", "Sun_1.png")
        {
            X = x;
            Y = y;
            _existTime = 0;
            SplashKit.SpriteSetX(this.Sprite, (float)X - 10);
            SplashKit.SpriteSetY(this.Sprite, (float)Y - 30);
        }

        public int ExistTime
        {
            get
            {
                return _existTime;
            }
        }

        public void TickSinceSpawns()
        {
            _existTime++;
        }

        public bool IsAt(Point2D pt)
        {
            if (SplashKit.SpritePointCollision(this.Sprite,pt))
            {
                return true;
            }
            return false;
        }
    }
}
