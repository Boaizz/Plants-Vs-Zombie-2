using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram
{
    public class Menu : GameObject
    {
        public Menu() :base("Main Menu","menu1.jpg")
        {
            SplashKit.SpriteSetX(this.Sprite, 0);
            SplashKit.SpriteSetY(this.Sprite, 0);
        }

    }
}
