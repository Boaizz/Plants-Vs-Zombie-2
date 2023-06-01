using SplashKitSDK;

namespace CustomProgram
{
    public class Brain : GameObject //losing message
    {
        public Brain() : base("Defeat", "losing.png")
        {
            SplashKit.SpriteSetX(this.Sprite, 380);
            SplashKit.SpriteSetY(this.Sprite, 110);
        }
    }
}
