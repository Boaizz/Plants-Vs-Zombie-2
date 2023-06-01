using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram.Buttons
{
    public class ButtonA : Button //this is the button to move to the pick items
    {
        public ButtonA() : base("ButtonA", "buttonA3.png", 597, 570)
        {
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("ButtonA1", "buttonA1.png"), "On Hover");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("ButtonA2", "buttonA2.png"), "On Click");
        }


    }
}
