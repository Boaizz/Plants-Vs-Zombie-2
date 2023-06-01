using System;
using SplashKitSDK;

namespace CustomProgram.Bullets
{
    class GreenPea : Bullet
    {
        public GreenPea(double x, double y) : base("Green Pea", "pea.png")
        {
            X = x + 25;
            Y = y - 40;
            Damage = 10;
            SplashKit.SpriteSetVelocity(Sprite, Vel);
            SplashKit.SpriteSetX(Sprite, (float)X);
            SplashKit.SpriteSetY(Sprite, (float)Y);
        }
    }
}
