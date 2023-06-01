using CustomProgram.Bullets;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    class PeaShooter : ShooterPlant
    {
        public PeaShooter(double x, double y) : base("Pea Shooter", "peashooter.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 40);
        }

        public override void Shoot()
        {
            GreenPea greenPea = new GreenPea(X, Y);
            base.Shoot();
            BulletPeas.Add(greenPea);
        }
    }
}
