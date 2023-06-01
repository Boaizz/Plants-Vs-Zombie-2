﻿using SplashKitSDK;

namespace CustomProgram.Zombies
{
    public class ConeheadZombie : Zombie
    {
        public ConeheadZombie() : base("Conehead Zombie", "Coneheadzombie.png")
        {
            int row = SplashKit.Rnd(0, 5);
            if (row == 4)
            {
                Y = 120 + 95 * row;
            }
            else if (row == 3)
            {
                Y = 110 + 95 * row;
            }
            else if (row == 0)
            {
                Y = 80;
            }
            else if (row == 1)
            {
                Y = 90 + 95 * row;
            }
            else
            {
                Y = 100 + 95 * row;
            }
            X = SplashKit.ScreenWidth() + 50;
            Health = 240;
            Vector2D _vel = new Vector2D();
            _vel.X = -0.5;
            _vel.Y = 0;
            Vel = _vel;
            Damage = 20;
            Row = row;
            SplashKit.SpriteSetX(Sprite, (float)X);
            SplashKit.SpriteSetY(Sprite, (float)Y);
            SplashKit.SpriteSetVelocity(Sprite, Vel);
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Conehead Attack", "ConeheadZombieAttack.png"), "Conehead Attack");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Normal Zombie", "normalzombie.png"), "Normal Zombie");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Normal Zombie Attack", "NormalZombieAttack.png"), "Attack");
        }

        public override void ChangeLayer()
        {
            if (Health > 100 && IsEating)
            {
                SplashKit.SpriteHideLayer(Sprite, 0);
                SplashKit.SpriteHideLayer(Sprite, 2);
                SplashKit.SpriteHideLayer(Sprite, 3);
                SplashKit.SpriteShowLayer(Sprite, 1);
            }
            else if (Health > 100 && !IsEating)
            {
                SplashKit.SpriteHideLayer(Sprite, 1);
                SplashKit.SpriteHideLayer(Sprite, 2);
                SplashKit.SpriteHideLayer(Sprite, 3);
                SplashKit.SpriteShowLayer(Sprite, 0);
            }
            else if (Health <= 100 && IsEating)
            {
                SplashKit.SpriteHideLayer(Sprite, 1);
                SplashKit.SpriteHideLayer(Sprite, 0);
                SplashKit.SpriteHideLayer(Sprite, 2);
                SplashKit.SpriteShowLayer(Sprite, 3);
            }
            else if (Health <= 100 && !IsEating)
            {
                SplashKit.SpriteHideLayer(Sprite, 1);
                SplashKit.SpriteHideLayer(Sprite, 0);
                SplashKit.SpriteHideLayer(Sprite, 3);
                SplashKit.SpriteShowLayer(Sprite, 2);
            }
        }
    }
}
