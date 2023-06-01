using SplashKitSDK;

namespace CustomProgram.Buttons
{
    public class ButtonY : Button
    {
        public ButtonY() : base("button Y1", "buttonY1.png", 1100, 200) //this is the button for returning the menu
        {
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Button Y2", "buttonY2.png"), "On Hover");
            SplashKit.SpriteAddLayer(Sprite, new Bitmap("Button Y3", "buttonY3.png"), "On Click");
        }
    }
}
