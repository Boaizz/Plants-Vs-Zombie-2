using CustomProgram.Plants;
using SplashKitSDK;

namespace CustomProgram.Bullets
{
    class LightningPea : Bullet
    {
        public LightningPea(ShooterPlant shooter) : base("Electric Pea", "lightningpea.png")
        {
            X = shooter.X + 25;
            Y = shooter.Y - 40;
            Damage = 15;
            SplashKit.SpriteSetVelocity(Sprite, Vel);
            SplashKit.SpriteSetX(Sprite, (float)X);
            SplashKit.SpriteSetY(Sprite, (float)Y);
        }
    }
}
