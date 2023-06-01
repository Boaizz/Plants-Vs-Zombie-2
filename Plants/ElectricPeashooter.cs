using CustomProgram.Bullets;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    class ElectricPeashooter : ShooterPlant
    {
        public ElectricPeashooter(double x, double y) : base("Electric Peashooter", "electricpea.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 40);
        }

        public override void Shoot()
        {
            LightningPea lightningPea = new LightningPea(this);
            base.Shoot();
            BulletPeas.Add(lightningPea);
        }
    }
}
