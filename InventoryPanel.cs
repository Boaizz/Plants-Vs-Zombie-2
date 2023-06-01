using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class InventoryPanel : GameObject
    {
        public InventoryPanel() :base("Inventory Panel","panel_background_resized.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 315);
            SplashKit.SpriteSetY(this.Sprite, 100);
        }


    }
}
