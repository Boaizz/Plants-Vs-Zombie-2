using CustomProgram.Zombies;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    public class PotatoMine : Plant
    {
        private int _plantedTime;
        private int _timeSinceExplode;
        private bool _isexploded;
        private int _damage;
        public PotatoMine(double x, double y) : base("Potato Mine Init", "PotatoMineInit.png")
        {
            X = x;
            Y = y;
            _damage = 500;
            IsExplode = false;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 40);
            Sprite.AddLayer(new Bitmap("Potato Mine", "PotatoMine.png"), "Potato Mine");
            Sprite.AddLayer(new Bitmap("Potato Mine Explode", "PotatoMineExplode.png"), "Exploded");
        }

        public int PlantedTime //time since it planted
        {
            get
            {
                return _plantedTime;
            }
        }

        public int TimeSinceExploded //time since it blow off zombie
        {
            get
            {
                return _timeSinceExplode;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        public bool IsExplode
        {
            get
            {
                return _isexploded;
            }
            set
            {
                _isexploded = value;
            }
        }


        public void ChangeState()
        {
            _plantedTime++;
            if (IsExplode)
            {
                _timeSinceExplode++;
            }
            ChangeLayer();
        }

        private void ChangeLayer()
        {
            if (IsExplode)
            {
                SplashKit.SpriteHideLayer(Sprite, 1);
                SplashKit.SpriteShowLayer(Sprite, 2);
            }
            else if (PlantedTime >= 800)
            {
                SplashKit.SpriteHideLayer(Sprite, 0);
                SplashKit.SpriteShowLayer(Sprite, 1);
            }
        }

        public override void BeAttacked(Zombie zombie)
        {
            Health -= zombie.Damage;
        }
    }
}
