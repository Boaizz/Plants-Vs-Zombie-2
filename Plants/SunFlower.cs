using CustomProgram.Zombies;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    public class SunFlower : Plant
    {
        private int _cooldown;
        private int _sunGenTime;
        public SunFlower(double x, double y) : base("Sunflower", "sunflower.png")
        {
            X = x;
            Y = y;
            SplashKit.SpriteSetX(Sprite, (float)X - 15);
            SplashKit.SpriteSetY(Sprite, (float)Y - 35);
            _cooldown = 0;
            _sunGenTime = SplashKit.Rnd(500, 700);
        }

        public int Cooldown
        {
            get
            {
                return _cooldown;
            }
        }

        public int SunGenTime
        {
            get
            {
                return _sunGenTime;
            }
        }

        public void TickSinceLastCreateSun()
        {
            _cooldown++;
        }

        public void ResetTick()
        {
            _cooldown = 0;
        }

        public override void BeAttacked(Zombie zombie)
        {
            Health -= zombie.Damage;
        }
    }
}
