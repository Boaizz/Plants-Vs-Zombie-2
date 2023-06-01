using SplashKitSDK;

namespace CustomProgram.Bullets
{
    public class Bullet : GameObject //shot by shooting plant
    {
        private Vector2D _vel;
        private int _damage;
        public Bullet(string name, string filename) : base(name, filename)
        {
            _vel = new Vector2D();
            _vel.X = 5;
            _vel.Y = 0;
            Vel = _vel;
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
    }
}
