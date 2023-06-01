using CustomProgram.Plants;
using SplashKitSDK;

namespace CustomProgram.Bullets
{
    class IcePea : Bullet
    {
        public IcePea(ShooterPlant shooter) : base("Ice Pea", "peaice.png")
        {
            X = shooter.X + 25;
            Y = shooter.Y - 40;
            Damage = 10;
            SplashKit.SpriteSetVelocity(Sprite, Vel);
            SplashKit.SpriteSetX(Sprite, (float)X);
            SplashKit.SpriteSetY(Sprite, (float)Y);
        }
    }
}
