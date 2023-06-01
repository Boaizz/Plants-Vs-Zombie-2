using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Taco : GameObject //winning message
    {
        public Taco() :base("Taco","taco.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 380);
            SplashKit.SpriteSetY(this.Sprite, 110);
        }
    }
}
