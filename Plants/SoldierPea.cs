using CustomProgram.Bullets;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    public class SoldierPea : ShooterPlant
    {
        public SoldierPea(double x, double y) : base("SoldierPea", "soldierpea1.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 40);
        }


        public override void Shoot()
        {
            base.Shoot();
            BulletPeas.Add(new GreenPea(X, Y));
            BulletPeas.Add(new GreenPea(X + 40, Y));
            BulletPeas.Add(new GreenPea(X + 80, Y));
            BulletPeas.Add(new GreenPea(X + 120, Y));
        }
    }


}
