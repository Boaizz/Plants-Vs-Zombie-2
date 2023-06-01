using CustomProgram.Bullets;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    public class IcePeaShooter : ShooterPlant
    {
        public IcePeaShooter(double x, double y) : base("Snow Pea", "snowpea.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 40);
        }

        public override void Shoot() //shoot ice pea
        {
            IcePea icepea = new IcePea(this);
            base.Shoot();
            BulletPeas.Add(icepea);
        }
    }
}
