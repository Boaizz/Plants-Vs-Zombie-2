using SplashKitSDK;

namespace CustomProgram.Buttons
{
    public class ButtonX : Button //this is the button for starting the game
    {
        public ButtonX() : base("Button X1", "buttonX1.png", 1100, 300)
        {
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Button X2", "buttonX2.png"), "On Hover");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Button X3", "buttonX3.png"), "On Click");
        }
    }
}
