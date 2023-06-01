using CustomProgram.Bullets;
using SplashKitSDK;

namespace CustomProgram.Zombies
{
    public abstract class Zombie : GameObject
    {
        private int _health;
        private Vector2D _vel;
        private int _damage;
        private bool _isEating;
        private int _row;
        private int _chewingTime;
        private int _stunningTime;
        private int _slowingTime;
        private bool _isSlow;
        private bool _isStun;
        private bool _isBlowedByMine;
        public Zombie(string name, string filename) : base(name, filename)
        {
            _vel = new Vector2D();
            IsEating = false;
            _isSlow = false;
            _isBlowedByMine = false;
        }


        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public void BeAttacked(Bullet pea)
        {
            if (pea.GetType().Equals(typeof(IcePea)))
            {
                _slowingTime = 60;
            }
            if (pea.GetType().Equals(typeof(LightningPea)))
            {
                _stunningTime = 60;
            }
            Health -= pea.Damage;
        }

        public void ChangeSpeed()
        {
            if (IsEating)
            {
                SplashKit.SpriteSetDx(Sprite, 0);
            }
            else if (_slowingTime > 0) SplashKit.SpriteSetDx(Sprite, -0.2f); //change speed when icepea hit
            else if (_stunningTime > 0) SplashKit.SpriteSetDx(Sprite, 0); //change speed when lightningpea hit
            else SplashKit.SpriteSetDx(Sprite, -0.5f); //normal speed
        }

        public void DecreaseSlowingTime()
        {
            if (_slowingTime > 0)
            {
                _slowingTime--;
            }
        }
        public void DecreaseStunningTime()
        {
            if (_stunningTime > 0)
            {
                _stunningTime--;
            }
        }

        public void TickSinceFirstBite()
        {
            _chewingTime++;
        }

        public bool IsBlowedByMine
        {
            get
            {
                return _isBlowedByMine;
            }
            set
            {
                _isBlowedByMine = value;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }


        public bool IsEating
        {
            get
            {
                return _isEating;
            }
            set
            {
                _isEating = value;
            }
        }

        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }

        public int ChewingTime
        {
            get
            {
                return _chewingTime;
            }
            set
            {
                _chewingTime = value;
            }
        }

        public Vector2D Vel
        {
            get
            {
                return _vel;
            }
            set
            {
                _vel = value;
            }
        }
        public abstract void ChangeLayer();
    }
}
