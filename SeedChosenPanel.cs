using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class SeedChosenPanel : GameObject
    {
        public SeedChosenPanel() :base("ItemChosenPanel","ItemChosen.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 324);
            SplashKit.SpriteSetY(this.Sprite, 0);
        }
    }
}
