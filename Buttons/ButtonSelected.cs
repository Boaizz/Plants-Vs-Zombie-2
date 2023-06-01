using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram.Buttons
{
    public class ButtonSelected : Button //this button is used for selecting the card
    {
        public ButtonSelected() : base("selected Button", "buttonB1.png", 1050, 250)
        {
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("selected Button 1", "buttonB2.png"), "On Hover");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("selected Button 2", "buttonB3.png"), "On Click");
        }

        public override void CheckButtonState()
        {
            base.CheckButtonState();
            if (IsClickedTime >= 15)
            {
                IsClickedTime = 0;
            }
        }
    }
}
