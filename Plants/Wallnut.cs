using CustomProgram.Zombies;
using SplashKitSDK;

namespace CustomProgram.Plants
{
    public class Wallnut : Plant
    {
        public Wallnut(double x, double y) : base("Wallnut", "Wallnut.png")
        {
            X = x;
            Y = y;
            Health = 300;
            SplashKit.SpriteSetX(Sprite, (float)X - 20);
            SplashKit.SpriteSetY(Sprite, (float)Y - 50);
            Sprite.AddLayer(new Bitmap("Wallnut Cracked 1", "Wallnut_cracked1.png"), "Cracked 1");
            Sprite.AddLayer(new Bitmap("Wallnut Cracked 2", "Wallnut_cracked2.png"), "Cracked 2");
        }

        public void ChangeLayer()
        {
            if (Health > 100 && Health <= 200)
            {
                SplashKit.SpriteHideLayer(Sprite, 0);
                SplashKit.SpriteShowLayer(Sprite, 1);
            }
            else if (Health <= 100)
            {
                SplashKit.SpriteHideLayer(Sprite, 1);
                SplashKit.SpriteShowLayer(Sprite, 2);
            }
        }

        public override void BeAttacked(Zombie zombie)
        {
            Health -= zombie.Damage;
        }
    }
}
