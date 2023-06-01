using CustomProgram.Bullets;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    public class Repeater : ShooterPlant
    {
        public Repeater(double x, double y) : base("Repeater", "repeater.png")
        {
            X = x;
            Y = y;
            Health = 100;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 40);
        }


        public override void Shoot() //shoot 2 green pea
        {
            base.Shoot();
            BulletPeas.Add(new GreenPea(X + 40, Y));
            BulletPeas.Add(new GreenPea(X, Y));
        }
    }


}
